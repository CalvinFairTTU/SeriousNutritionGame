using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerMovement : MonoBehaviour
{

	public int speed = 0;
	public GameObject player;
	public Slider progressBar;

	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Vector3 mouseCord = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Collider2D playerTouch = player.GetComponent<Collider2D>();

			if (playerTouch.OverlapPoint(mouseCord) && player.transform.position.y == 1)
			{
				this.transform.position = new Vector3(-4.16f, -3.72f, 0);
			}
			if (playerTouch.OverlapPoint(mouseCord) && player.transform.position.y != 1)
			{
				this.transform.position = new Vector3(-4.16f, 1, 0);
			}
		}
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
		//food.gameObject.SetActive(false);
		Destroy(food.gameObject);

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
