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
        BUMPED,
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

    // Use this for initialization
    void Start ()
    {
        this.state = cookieState.INITIAL;
        speed2 = speed / Mathf.Sqrt(2);
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        //Debug.Log("state = " + this.state);
        switch(this.state)
        {
            case cookieState.INITIAL:
                randomNum = Random.Range(0, 7);
                SetStateFromRandom(randomNum);
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
            case cookieState.BUMPED:
                randomNum = (int)Random.Range(0, 7.999999f);
                //Debug.Log("randonNum = " + randomNum);
                SetStateFromRandom(randomNum);
                break;
            case cookieState.RANDOM:
                randomNum = (int)Random.Range(0, 7.999999f);
                //Debug.Log("randonNum = " + randomNum);
                SetStateFromRandom(randomNum);
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
        else
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
                    break;
                case cookieState.LEFTUP: state = LEFTUP[colIndex];
                    break;
                case cookieState.LEFTDOWN: state = LEFTDOWN[colIndex];
                    break;
                case cookieState.RIGHT: state = RIGHT[colIndex];
                    break;
                case cookieState.RIGHTUP: state = RIGHTUP[colIndex];
                    break;
                case cookieState.RIGHTDOWN: state = RIGHTDOWN[colIndex];
                    break;
                case cookieState.UP: state = UP[colIndex];
                    break;
                case cookieState.DOWN: state = DOWN[colIndex];
                    break;
                default: state = cookieState.RANDOM;
                    break;
            }
        }
    }

    private void SetStateFromRandom(int num)
    {
        switch(num)
        {
            case 0:
                this.state = cookieState.LEFT;
                break;
            case 1:
                this.state = cookieState.LEFTUP;
                break;
            case 2:
                this.state = cookieState.LEFTDOWN;
                break;
            case 3:
                this.state = cookieState.RIGHT;
                break;
            case 4:
                this.state = cookieState.RIGHTUP;
                break;
            case 5:
                this.state = cookieState.RIGHTDOWN;
                break;
            case 6:
                this.state = cookieState.UP;
                break;
            case 7:
                this.state = cookieState.DOWN;
                break;
            default:
                this.state = cookieState.BUMPED;
                break;
        }
        //Debug.Log("New State = " + this.state);
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
