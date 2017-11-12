using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyingObjectsScript : MonoBehaviour
{

	public Slider progressBar;
	public Collider2D player;
	public Collider2D DestroyingZone;

	//public float progressPoints = progressBar.value;

	void OnTriggerEnter2D(Collider2D food)
	{
		if (food.IsTouching(player))
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
		}
		else if (food.IsTouching(DestroyingZone))
		{
			if (food.tag == "Bad_Food")
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
		}

		Destroy(food.gameObject);

		if (progressBar.value >= 1f)
		{
			Debug.Log("You won the game!");
			//gameObject.GetComponent<WinGame> ().Win ();
			//gameObject.GetComponent<EdgeCollider2D> ().enabled = false;
		}
	}
}
