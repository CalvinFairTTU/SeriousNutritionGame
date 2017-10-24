using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class DogEatScript : MonoBehaviour {

	public Slider progressBar;
	float progressPoints;
   
    void OnTriggerStay2D(Collider2D food) {
        if (food.tag == "Good_Food") {
			if (progressPoints < 1f) {
				progressPoints += 0.05f;
			}
        }
        else {
			if (progressPoints > 0f) {
				progressPoints -= 0.05f;
			}
        }

		progressBar.value = progressPoints;
        Destroy(food.gameObject);

		if (progressBar.value >= 1f) {
			Debug.Log ("You won the game!");
			//gameObject.GetComponent<WinGame> ().Win ();
			//gameObject.GetComponent<EdgeCollider2D> ().enabled = false;
		}
    }
}