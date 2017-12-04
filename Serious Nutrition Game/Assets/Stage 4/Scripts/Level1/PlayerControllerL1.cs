using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControllerL1 : MonoBehaviour {

	private Rigidbody2D rigidBody;
	private float moveHorizontal = 0;
	public Slider progressBar;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody2D> ();	
	}

	void Update() {
		if (transform.position.y > 3.6f)
			transform.position = new Vector2 (transform.position.x, 3.6f);
		if (transform.position.y < -3.6f)
			transform.position = new Vector2(transform.position.x, -3.6f);
	}

	void FixedUpdate() {
		float moveVertical = Input.GetAxis ("Vertical");
		rigidBody.velocity = new Vector2 (moveHorizontal, moveVertical*10f);
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.CompareTag ("BadFood")) {
			if (progressBar.value < 1f && progressBar.value > 0f)
				progressBar.value -= 0.05f;
			other.gameObject.SetActive (false);
		}
		else if (other.gameObject.CompareTag ("GoodFood")) {
			other.gameObject.SetActive (false);
			if (progressBar.value < 1f)
				progressBar.value += 0.2f;
		}

		if (progressBar.value >= 1f) {
			Debug.Log ("You won the game!");
		}
	}
}
