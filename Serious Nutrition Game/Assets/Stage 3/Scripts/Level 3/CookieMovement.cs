using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookieMovement : MonoBehaviour {

    public float speed;
    public Rigidbody2D rb2d;
    
    private cookieState state;
    private float speed2;
    private int randomNum;

    enum cookieState
    {
        INITIAL,
        LEFT,
        LEFTUP,
        LEFTDOWN,
        RIGHT,
        RIGHTUP,
        RIGHTDOWN,
        UP,
        DOWN,
        RANDOM
    };
       
    //                                    "LowerWall",          "UpperWall",            "LeftWall",             "RightWall"
    private cookieState[] LEFT =        { cookieState.UP,       cookieState.DOWN,       cookieState.RANDOM,     cookieState.RANDOM      };
    private cookieState[] LEFTUP =      { cookieState.LEFTUP,   cookieState.DOWN,       cookieState.RIGHTUP,    cookieState.LEFTUP      };
    private cookieState[] LEFTDOWN =    { cookieState.LEFTUP,   cookieState.DOWN,       cookieState.RIGHTDOWN,  cookieState.LEFT        };
    private cookieState[] RIGHT =       { cookieState.RIGHTUP,  cookieState.RIGHTDOWN,  cookieState.RANDOM,     cookieState.RANDOM      };
    private cookieState[] RIGHTUP =     { cookieState.UP,       cookieState.RIGHTDOWN,  cookieState.RIGHT,      cookieState.LEFTUP      };
    private cookieState[] RIGHTDOWN =   { cookieState.RIGHTUP,  cookieState.DOWN,       cookieState.RIGHT,      cookieState.LEFTDOWN    };
    private cookieState[] UP =          { cookieState.RANDOM,   cookieState.RANDOM,     cookieState.RIGHTUP,    cookieState.LEFTUP      };
    private cookieState[] DOWN =        { cookieState.RANDOM,   cookieState.RANDOM,     cookieState.RIGHTDOWN,  cookieState.LEFTDOWN    };

    private cookieState[] general = { cookieState.LEFT, cookieState.LEFTUP, cookieState.LEFTDOWN, cookieState.RIGHT, cookieState.RIGHTUP, cookieState.RIGHTDOWN, cookieState.UP, cookieState.DOWN };
    private cookieState[] forLEFTonLeftWall = { cookieState.RIGHT, cookieState.RIGHTUP, cookieState.RIGHTDOWN, cookieState.RIGHT, cookieState.RIGHTUP, cookieState.RIGHTDOWN, cookieState.RIGHT, cookieState.RIGHT };
    private cookieState[] forLEFTonRightWall = { cookieState.LEFT, cookieState.LEFTUP, cookieState.LEFTDOWN, cookieState.LEFT, cookieState.LEFTUP, cookieState.LEFTDOWN, cookieState.LEFT, cookieState.LEFT };
    private cookieState[] forRIGHTonLeftWall = { cookieState.RIGHT, cookieState.RIGHTUP, cookieState.RIGHTDOWN, cookieState.RIGHT, cookieState.RIGHTUP, cookieState.RIGHTDOWN, cookieState.RIGHT, cookieState.RIGHT };
    private cookieState[] forRIGHTonRightWall = { cookieState.LEFT, cookieState.LEFTUP, cookieState.LEFTDOWN, cookieState.LEFT, cookieState.LEFTUP, cookieState.LEFTDOWN, cookieState.LEFT, cookieState.LEFT };
    private cookieState[] forUPonLowerWall = { cookieState.LEFTUP, cookieState.LEFTUP, cookieState.LEFTUP, cookieState.RIGHTUP, cookieState.RIGHTUP, cookieState.RIGHTUP, cookieState.UP, cookieState.UP };
    private cookieState[] forUPonUpperWall = { cookieState.LEFTDOWN, cookieState.LEFTDOWN, cookieState.LEFTDOWN, cookieState.RIGHTDOWN, cookieState.RIGHTDOWN, cookieState.RIGHTDOWN, cookieState.DOWN, cookieState.DOWN };
    private cookieState[] forDOWNonLowerWall = { cookieState.LEFTUP, cookieState.LEFTUP, cookieState.LEFTUP, cookieState.RIGHTUP, cookieState.RIGHTUP, cookieState.RIGHTUP, cookieState.UP, cookieState.UP };
    private cookieState[] forDOWNonUpperWall = { cookieState.LEFTDOWN, cookieState.LEFTDOWN, cookieState.LEFTDOWN, cookieState.RIGHTDOWN, cookieState.RIGHTDOWN, cookieState.RIGHTDOWN, cookieState.DOWN, cookieState.DOWN };

    private cookieState[] selector;
   
    // Use this for initialization
    void Start ()
    {
        this.state = cookieState.INITIAL;
        speed2 = speed / Mathf.Sqrt(2);
        selector = general;
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        switch(this.state)
        {
            case cookieState.INITIAL:
                randomNum = (int)Random.Range(0, 7.999999f);
                SetStateFromRandom(randomNum,selector);
                break;
            case cookieState.LEFT:
                rb2d.velocity = Vector2.left * speed;
                break;
            case cookieState.LEFTUP:
                rb2d.velocity = new Vector2(-1,1) * speed2;
                break;
            case cookieState.LEFTDOWN:
                rb2d.velocity = new Vector2(-1,-1) * speed2;
                break;
            case cookieState.RIGHT:
                rb2d.velocity = Vector2.right * speed;
                break;
            case cookieState.RIGHTUP:
                rb2d.velocity = new Vector2(1,1) * speed2;
                break;
            case cookieState.RIGHTDOWN:
                rb2d.velocity = new Vector2(1,-1) * speed2;
                break;
            case cookieState.UP:
                rb2d.velocity = Vector2.up * speed;
                break;
            case cookieState.DOWN:
                rb2d.velocity = Vector2.down * speed;
                break;
            case cookieState.RANDOM:
                randomNum = (int)Random.Range(0, 7.999999f);
                SetStateFromRandom(randomNum,selector);
                break;
            default:
                break;
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
       int colIndex;
       if (col.tag == "Player")
       {
            AvoidPlayer(col.gameObject);
       }
        else if (col.tag != "GoodFood")
        {
            switch (col.tag)
            {
                case "LowerWall": colIndex = 0;                    
                    break;
                case "UpperWall": colIndex = 1;
                    break;
                case "LeftWall": colIndex = 2;
                    break;
                case "RightWall": colIndex = 3;
                    break;
                default:
                    colIndex = 0;
                    break;
            }
            switch(state)
            {
                case cookieState.LEFT: state = LEFT[colIndex];
                    if (colIndex == 2) { selector = forLEFTonLeftWall; }
                    else if (colIndex == 3) { selector = forLEFTonRightWall; }
                    else { selector = general; }
                    break;
                case cookieState.LEFTUP: state = LEFTUP[colIndex];
                    break;
                case cookieState.LEFTDOWN: state = LEFTDOWN[colIndex];
                    break;
                case cookieState.RIGHT: state = RIGHT[colIndex];
                    if (colIndex == 2) { selector = forRIGHTonLeftWall; }
                    else if (colIndex == 3) { selector = forRIGHTonRightWall; }
                    else { selector = general; }
                    break;
                case cookieState.RIGHTUP: state = RIGHTUP[colIndex];
                    break;
                case cookieState.RIGHTDOWN: state = RIGHTDOWN[colIndex];
                    break;
                case cookieState.UP: state = UP[colIndex];
                    if (colIndex == 0) { selector = forUPonLowerWall; }
                    else if (colIndex == 1) { selector = forUPonUpperWall; }
                    else { selector = general; }
                    break;
                case cookieState.DOWN: state = DOWN[colIndex];
                    if (colIndex == 0) { selector = forDOWNonLowerWall; }
                    else if (colIndex == 1) { selector = forDOWNonUpperWall; }
                    else { selector = general; }
                    break;
                default: state = cookieState.RANDOM;
                    selector = general;
                    break;
            }
        }
    }

    private void SetStateFromRandom(int num, cookieState[] selection)
    {
        this.state = selection[num];
        return;
    }
    
    private void AvoidPlayer(GameObject player)
    {
        Vector2 toPlayer = player.transform.position - this.transform.position;
        if (toPlayer.x >= 0)
        {
            if (toPlayer.y >= 0)
            {
                this.state = cookieState.LEFTDOWN;
            }
            else
            {
                this.state = cookieState.LEFTUP;
            }
        }
        else if (toPlayer.x < 0)
        {
            if (toPlayer.y >= 0)
            {
                this.state = cookieState.RIGHTDOWN;
            }
            else
            {
                this.state = cookieState.RIGHTUP;
            }
        }
    }
}
