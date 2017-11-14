using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S2L1Win : MonoBehaviour {
    
	public Slider progressBar;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D food) {
        if (food.transform.localScale == new Vector3(1.0f, 1.0f, 1.0f)) {
			progressBar.value += 0.05f;
			Destroy(food.gameObject);
        }
    }
}
