using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookieMovement : MonoBehaviour {

    public float speed;
    public Rigidbody2D rb2d;
    public int minTime;
    public int maxTime;

    private int randomNum;
    private int cycleCounter;
    private int WaitTime;

	// Use this for initialization
	void Start ()
    {
        randomNum = Random.Range(0, 3);
        cycleCounter = 0;
        WaitTime = Random.Range(minTime, maxTime);
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (cycleCounter < WaitTime)
        {
            cycleCounter++;
        }
        else
        {
            cycleCounter = 0;
            randomNum = Random.Range(0, 5);
            switch (randomNum)
            {
                case 0:
                case 1:
                    rb2d.velocity = (Vector2.right * speed);
                    break;
                case 2:
                case 3:
                    rb2d.velocity = (Vector2.left * speed);
                    break;
                case 4:
                    rb2d.velocity = (Vector2.down * speed);
                    break;
                case 5:
                    rb2d.velocity = (Vector2.up * speed);
                    break;
                default:
                    break;
            }
            WaitTime = Random.Range(minTime, maxTime);
        }
	}

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "LowerWall")
        {
            
        }
        else if (col.tag == "UpperWall")
        {
            
        }
        else if (col.tag == "LeftWall")
        {
            
        }
        else if (col.tag == "RightWall")
        {
           
        }
    }
}
