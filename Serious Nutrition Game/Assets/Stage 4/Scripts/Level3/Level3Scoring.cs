using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level3Scoring : MonoBehaviour {

	public Slider progressBar;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D food) {

		if (food.gameObject.CompareTag ("GoodFood"))
		if (progressBar.value < 1f)
			progressBar.value += 0.2f;

		if (food.gameObject.CompareTag ("BadFood"))
		if (progressBar.value < 1f && progressBar.value > 0f)
			progressBar.value -= 0.05f;


		if(progressBar.value >= 1f) {
			Debug.Log ("You won the game!");
			//gameObject.GetComponent<WinGame> ().Win ();
			//gameObject.GetComponent<EdgeCollider2D> ().enabled = false;
		}
	}

	void OnTriggerExit2D (Collider2D food) {

		if (food.gameObject.CompareTag ("GoodFood"))
		if (progressBar.value < 1f)
			progressBar.value -= 0.2f;

		if (food.gameObject.CompareTag ("BadFood"))
		if (progressBar.value < 1f && progressBar.value > 0f)
			progressBar.value += 0.05f;


		if(progressBar.value >= 1f) {
			Debug.Log ("You won the game!");
			//gameObject.GetComponent<WinGame> ().Win ();
			//gameObject.GetComponent<EdgeCollider2D> ().enabled = false;
		}
	}
}
