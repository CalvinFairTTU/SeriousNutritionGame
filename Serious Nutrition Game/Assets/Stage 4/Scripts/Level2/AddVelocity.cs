using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddVelocity : MonoBehaviour {

	private Rigidbody2D rigidBody;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody2D> ();	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		rigidBody.velocity = new Vector2 (5f, 0);		
	}
}
