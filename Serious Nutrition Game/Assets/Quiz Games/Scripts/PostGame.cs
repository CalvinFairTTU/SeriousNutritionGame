using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PostGame : MonoBehaviour {

	public GameObject foodItemOne;
	public GameObject foodItemTwo;
	public GameObject foodItemThree;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void firstFoodOption () {
		if (foodItemOne.tag == "Good_Food") {
			Debug.Log("Correct food!");
		} else {
			Debug.Log ("Wrong food!");
		}
	}

	public void secondFoodOption () {
        if (foodItemTwo.tag == "Good_Food") {
            Debug.Log("Correct food!");
        } else {
            Debug.Log("Wrong food!");
        }
    }

	public void thirdFoodOption () {
        if (foodItemThree.tag == "Good_Food"){
            Debug.Log("Correct food!");
        } else {
            Debug.Log("Wrong food!");
        }
    }
}
