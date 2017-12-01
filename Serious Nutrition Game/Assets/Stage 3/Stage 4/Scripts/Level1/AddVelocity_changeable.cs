using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddVelocity_changeable : MonoBehaviour {

	private Rigidbody2D rigidBody;
	public float moveHorizontal = 3f;

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
}
