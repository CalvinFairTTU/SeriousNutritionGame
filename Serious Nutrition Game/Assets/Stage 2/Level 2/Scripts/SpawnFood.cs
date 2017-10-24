using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFood : MonoBehaviour 
{
	public GameObject[] foods;
	public float dropSpeed;
	private float minSpawnTime = 1.5f;
	private float maxSpawnTime = 3f;

	void Start() 
	{
		StartCoroutine (Spawn());
	}

	IEnumerator Spawn()
	{
		while (true) {
			yield return new WaitForSeconds (Random.Range (minSpawnTime, maxSpawnTime));
			GameObject food = Instantiate (foods [Random.Range (0, foods.Length)], transform.position, transform.rotation) as GameObject;
		}
	}
}
