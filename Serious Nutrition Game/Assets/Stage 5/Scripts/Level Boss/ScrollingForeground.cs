using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingForeground : MonoBehaviour
{

	public float speed;

	private bool move = false;
	private Collider2D colObj;

	void OnTriggerStay2D(Collider2D col)
	{
		move = true;

		colObj = col;
	}

	void Update()
	{
		if (move && colObj.isActiveAndEnabled)
		{
			if (!colObj.gameObject.Equals(null))
			{
				colObj.transform.Translate(-speed * Time.deltaTime, 0, 0);
			}
		}


	}
}

