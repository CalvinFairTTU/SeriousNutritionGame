using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float jump_speed = 8f;
	private Rigidbody2D rigidBody;


	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody2D> ();
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButton (0)) 
		{
			rigidBody.velocity = new Vector2 (0, jump_speed);
		}
		
	}

	void OnTriggerEnter2D (Collider2D other) {
        if (other.gameObject.CompareTag("BadFood"))
            Destroy(other.gameObject);
        else if (other.gameObject.CompareTag("GoodFood"))
            Destroy(other.gameObject);
    }
}
