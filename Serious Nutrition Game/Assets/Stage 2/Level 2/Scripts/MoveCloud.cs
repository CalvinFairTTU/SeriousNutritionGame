using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCloud : MonoBehaviour 
{
	public float speed;
	private Vector2 pos1 = new Vector2 (-130f, 55f);
	private Vector2 pos2 = new Vector2 (170f, 55f);

	void Update () 
	{
		//move cloud back and forth between the boundaries of the screen 
		transform.position = Vector2.Lerp (pos1, pos2, Mathf.PingPong (Time.time * speed, 1f));
	}
}
