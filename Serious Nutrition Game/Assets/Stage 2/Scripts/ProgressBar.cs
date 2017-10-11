using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBar : MonoBehaviour {

    public float maxPoints = 100;
    public float currentPoints = 0;

	// Use this for initialization
	void Start () {
        currentPoints = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetMouseButtonDown(0))
        {
            //progressUp();
        }
	}

    public void progressUp()
    {
        currentPoints += 10;
        transform.localScale = new Vector3(currentPoints, 1, 1);
    }

    public void progressDown()
    {
        currentPoints -= 10;
        transform.localScale = new Vector3(currentPoints, 1, 1);
    }
}
