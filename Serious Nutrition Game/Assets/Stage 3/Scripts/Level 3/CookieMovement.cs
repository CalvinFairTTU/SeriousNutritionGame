using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookieMovement : MonoBehaviour {

    public float speed;
    public Rigidbody2D rb2d;
    
    private cookieState state;
    private float sum;
    private float speed2;
    private int randomNum;

    enum cookieState
    {
        LEFT,
        LEFTUP,
        LEFTDOWN,
        RIGHT,
        RIGHTUP,
        RIGHTDOWN,
        UP,
        DOWN,
        BUMPED
    };

	// Use this for initialization
	void Start ()
    {
        randomNum = Random.Range(0, 7);
        SetStateFromRandom(randomNum);
        speed2 = speed / Mathf.Sqrt(2);
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        Debug.Log("state = " + this.state);
        switch(this.state)
        {
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
                randomNum = (int)Random.Range(0, 7);
                Debug.Log("randonNum = " + randomNum);
                SetStateFromRandom(randomNum);
                break;
            default:
                break;
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        switch(this.state)
        {
            case cookieState.LEFT:
                switch(col.tag)
                {
                    case "LowerWall":
                        this.state = cookieState.UP;
                        break;
                    case "UpperWall":
                        this.state = cookieState.DOWN;
                        break;
                    case "LeftWall":
                        //this.state = cookieState.UP;
                        randomNum = Random.Range(0, 7);
                        SetStateFromRandom(randomNum);
                        break;
                    case "RightWall":
                        //this.state = cookieState.UP;
                        randomNum = Random.Range(0, 7);
                        SetStateFromRandom(randomNum);
                        break;
                    default:
                        this.state = cookieState.BUMPED;
                        break;
                }
                break;
            case cookieState.LEFTUP:
                switch (col.tag)
                {
                    case "LowerWall":
                        this.state = cookieState.LEFTUP;
                        break;
                    case "UpperWall":
                        this.state = cookieState.DOWN;
                        break;
                    case "LeftWall":
                        this.state = cookieState.RIGHTUP;
                        break;
                    case "RightWall":
                        this.state = cookieState.LEFTUP;
                        break;
                    default:
                        this.state = cookieState.BUMPED;
                        break;
                }
                break;
            case cookieState.LEFTDOWN:
                switch (col.tag)
                {
                    case "LowerWall":
                        this.state = cookieState.LEFTUP;
                        break;
                    case "UpperWall":
                        this.state = cookieState.DOWN;
                        break;
                    case "LeftWall":
                        this.state = cookieState.RIGHTDOWN;
                        break;
                    case "RightWall":
                        this.state = cookieState.LEFT;
                        break;
                    default:
                        this.state = cookieState.BUMPED;
                        break;
                }
                break;
            case cookieState.RIGHT:
                switch (col.tag)
                {
                    case "LowerWall":
                        this.state = cookieState.RIGHTUP;
                        break;
                    case "UpperWall":
                        this.state = cookieState.RIGHTDOWN;
                        break;
                    case "LeftWall":
                        //this.state = cookieState.UP;
                        randomNum = Random.Range(0, 7);
                        SetStateFromRandom(randomNum);
                        break;
                    case "RightWall":
                        //this.state = cookieState.UP;
                        randomNum = Random.Range(0, 7);
                        SetStateFromRandom(randomNum);
                        break;
                    default:
                        this.state = cookieState.BUMPED;
                        break;
                }
                break;
            case cookieState.RIGHTUP:
                switch (col.tag)
                {
                    case "LowerWall":
                        this.state = cookieState.UP;
                        break;
                    case "UpperWall":
                        this.state = cookieState.RIGHTDOWN;
                        break;
                    case "LeftWall":
                        this.state = cookieState.RIGHT;
                        break;
                    case "RightWall":
                        this.state = cookieState.LEFTUP;
                        break;
                    default:
                        this.state = cookieState.BUMPED;
                        break;
                }
                break;
            case cookieState.RIGHTDOWN:
                switch (col.tag)
                {
                    case "LowerWall":
                        this.state = cookieState.RIGHTUP;
                        break;
                    case "UpperWall":
                        this.state = cookieState.DOWN;
                        break;
                    case "LeftWall":
                        this.state = cookieState.RIGHT;
                        break;
                    case "RightWall":
                        this.state = cookieState.LEFTDOWN;
                        break;
                    default:
                        this.state = cookieState.BUMPED;
                        break;
                }
                break;
            case cookieState.UP:
                switch (col.tag)
                {
                    case "LowerWall":
                        //this.state = cookieState.UP;
                        randomNum = Random.Range(0, 7);
                        SetStateFromRandom(randomNum);
                        break;
                    case "UpperWall":
                        //this.state = cookieState.DOWN;
                        randomNum = Random.Range(0, 7);
                        SetStateFromRandom(randomNum);
                        break;
                    case "LeftWall":
                        this.state = cookieState.RIGHTUP;
                        break;
                    case "RightWall":
                        this.state = cookieState.LEFTUP;
                        break;
                    default:
                        this.state = cookieState.BUMPED;
                        break;
                }
                break;
            case cookieState.DOWN:
                switch (col.tag)
                {
                    case "LowerWall":
                        //this.state = cookieState.UP;
                        randomNum = Random.Range(0, 7);
                        SetStateFromRandom(randomNum);
                        break;
                    case "UpperWall":
                        //this.state = cookieState.DOWN;
                        randomNum = Random.Range(0, 7);
                        SetStateFromRandom(randomNum);
                        break;
                    case "LeftWall":
                        this.state = cookieState.RIGHTDOWN;
                        break;
                    case "RightWall":
                        this.state = cookieState.LEFTDOWN;
                        break;
                    default:
                        this.state = cookieState.BUMPED;
                        break;
                }
                break;
            case cookieState.BUMPED:
                break;
            default:
                break;
        }
        
    }

    private void SetStateFromRandom(int num)
    {
        switch(num)
        {
            case 0:
                Debug.Log("0");
                this.state = cookieState.LEFT;
                break;
            case 1:
                Debug.Log("1");
                this.state = cookieState.LEFTUP;
                break;
            case 2:
                Debug.Log("2");
                this.state = cookieState.LEFTDOWN;
                break;
            case 3:
                Debug.Log("3");
                this.state = cookieState.RIGHT;
                break;
            case 4:
                Debug.Log("4");
                this.state = cookieState.RIGHTUP;
                break;
            case 5:
                Debug.Log("5");
                this.state = cookieState.RIGHTDOWN;
                break;
            case 6:
                Debug.Log("6");
                this.state = cookieState.UP;
                break;
            case 7:
                Debug.Log("7");
                this.state = cookieState.DOWN;
                break;
            default:
                Debug.Log("def");
                this.state = cookieState.BUMPED;
                break;
        }
        Debug.Log("New State = " + this.state);
        return;
    }

    private bool ChangeState()
    {
        sum = (Mathf.Abs(this.gameObject.transform.position.x) + Mathf.Abs(this.gameObject.transform.position.y))/10000;
        if (Random.Range(0,7) <= sum)
        {
            return true;
        }
        return false;
    }
}
