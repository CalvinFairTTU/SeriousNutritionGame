using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {

    public float movementpos;
    public GameObject hero;

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.A))
        {
            moveLeft();
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveRight();
        }
    }

    public void moveLeft()
    {
        if (hero.transform.localPosition.x > -6)
        {
            movementpos -= 0.1f;
            hero.transform.localPosition = new Vector3(movementpos, -4, 1);
        }
    }

    public void moveRight()
    {
        if (hero.transform.localPosition.x < 7)
        {
            movementpos += 0.1f;
            hero.transform.localPosition = new Vector3(movementpos, -4, 1);
        }
    }
}
