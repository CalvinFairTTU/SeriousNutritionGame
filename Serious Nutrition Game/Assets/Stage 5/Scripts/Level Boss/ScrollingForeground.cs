using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingForeground : MonoBehaviour
{

	public float speed = 0.3f;


	void OnTriggerStay2D(Collider2D col)
	{
        col.transform.Translate(-speed * Time.deltaTime, 0, 0);
        col.transform.Translate(-0.05f, .001f, 0);

        //Rigidbody2D body = col.attachedRigidbody;
        //body.AddForce(Vector2.left, 0);
	}
}
