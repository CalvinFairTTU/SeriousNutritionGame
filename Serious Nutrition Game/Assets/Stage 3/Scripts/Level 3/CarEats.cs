using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarEats : MonoBehaviour {

    //public Slider progressBar;

    private float progressPoints;

	// Use this for initialization
	void Start ()
    {
        progressPoints = 0f;
        Debug.Log("progressPoints = " + progressPoints);
	}

    // Update is called once per frame
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "BadFood")
        {
            if (progressPoints > 0f)
            {
                progressPoints -= 0.05f;
            }
            Debug.Log("progressPoints = " + progressPoints);
        }
        else if (col.tag == "GoodFood")
        {
            progressPoints += 0.2f;
            Debug.Log("progressPoints = " + progressPoints);
            col.gameObject.SetActive(false);
        }
    }
}
