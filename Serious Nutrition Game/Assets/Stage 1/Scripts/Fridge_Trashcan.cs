using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fridge_Trashcan : MonoBehaviour {

	public Slider progressBar;
	public Collider2D dog;
	public Collider2D trash;
	//public float progressPoints = progressBar.value;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerExit2D(Collider2D food){
		if(food.tag== "Good_Food"){
			if (progressBar.value > 0f) {
				progressBar.value -= 0.05f;
				}
		}
		else if (food.tag == "Bad_Food"){
			if (progressBar.value < 1f) {
				progressBar.value += 0.05f;
				}
		}

	}
	void OnTriggerEnter2D (Collider2D food) {
		if (food.IsTouching(dog)) {
			if (food.tag == "Good_Food") {
				if (progressBar.value < 1f) {
					progressBar.value += 0.05f;
				}
			}
			else {
				if (progressBar.value > 0f) {
					progressBar.value -= 0.05f;
				}
			}
		} else if (food.IsTouching(trash)) {
			if (food.tag == "Bad_Food") {
				if (progressBar.value < 1f) {
					progressBar.value += 0.05f;
					Destroy(food.gameObject);
				}
			}
			else {
				if (progressBar.value > 0f) {
					progressBar.value -= 0.05f;
					Destroy(food.gameObject);
				}
			}
		}

		

		if (progressBar.value >= 1f) {
			Debug.Log ("You won the game!");
			//gameObject.GetComponent<WinGame> ().Win ();
			//gameObject.GetComponent<EdgeCollider2D> ().enabled = false;
		}
	}

}