using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour {

    public float movementpos;
    public GameObject villian;

    // Use this for initialization
    void Start()
    {
        moveRight();
        //movementAutomation();
    }

    void movementAutomation()
    {
        
    }

    public void moveLeft()
    {
        while (villian.transform.localPosition.x > -6)
        {
            movementpos -= 0.1f;
            villian.transform.localPosition = new Vector3(movementpos, 3.75f, 1);

            if(villian.transform.localPosition.x <= -6)
            {
                moveRight();
            }
        }
        
    }

    public void moveRight()
    {
        while (villian.transform.localPosition.x < 7)
        {
            movementpos += 0.1f;
            villian.transform.localPosition = new Vector3(movementpos, 3.75f, 1);

            if (villian.transform.localPosition.x >= 7)
            {
                moveLeft();
            }
        }
    }
}
