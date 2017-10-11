using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropFood : MonoBehaviour 
{
	private float dropSpeed = 25f;

	void Update () 
	{
		//if food drops below visible screen, destroy object
		//otherwise, allow the object to fall downwards at a constant rate 
		if (transform.position.y < -105f) {
			Destroy (gameObject);
		} else {
			transform.Translate (Vector2.down * dropSpeed * Time.deltaTime, Space.World);
		}
	}
}
