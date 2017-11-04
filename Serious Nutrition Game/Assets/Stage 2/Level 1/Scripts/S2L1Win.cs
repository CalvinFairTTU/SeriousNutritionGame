using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S2L1Win : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D food) {
        if (food.transform.localScale == new Vector3(1.0f, 1.0f, 1.0f)) {
            Debug.Log("Score increased.");
            Destroy(food);
        }
    }
}
