using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerMovement : MonoBehaviour
{

	public int speed = 0;
	Rigidbody2D player;
	public Slider progressBar;


	// Use this for initialization
	void Start()
	{

	}


	// Update is called once per frame
	void Update()
	{
	}

	void OnTriggerEnter2D(Collider2D food)
	{
		

		if (food.tag == "Good_Food")
		{
			if (progressBar.value < 1f)
			{
				progressBar.value += 0.05f;
			}
		}
		else
		{
			if (progressBar.value > 0f)
			{
				progressBar.value -= 0.05f;
			}
		}


		Debug.Log("Collided");
		food.gameObject.SetActive(false);


		if (progressBar.value >= 1f)
		{
			Debug.Log("You won the game!");
			//gameObject.GetComponent<WinGame> ().Win ();
			//gameObject.GetComponent<EdgeCollider2D> ().enabled = false;
		}
	}


	void OnMouseDown()
	{
		Debug.Log("toushced");

		if (this.transform.position.y == 1)
		{
			this.transform.position = new Vector3(-4.16f, -3.72f, 0);
		}
		else
		{
			this.transform.position = new Vector3(-4.16f, 1, 0);
		}

	}

}
