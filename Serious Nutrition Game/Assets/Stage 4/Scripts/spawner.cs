using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour {

	public GameObject[] foods;
	Vector3 whereToSpawn = new Vector3(-7,0, 0);
	public float spawnRate = 2f;
	float nextSpawn = 0.0f;


	// Use this for initialization
	void Start () {
		
	}

	void Update () {
		if (Time.time > nextSpawn) 
		{
			nextSpawn = Time.time + spawnRate;
			GameObject spanObject = foods [Random.Range (0, foods.Length)];
			Instantiate (spanObject, whereToSpawn, Quaternion.identity);
		}
	}
	/*
	// Update is called once per frame
	void Update () {
		countdown -= Time.deltaTime ();
		if (countdown <= 0) 
		{
			SpawnFood ();
			countdown = waitingForNextSpawn;
		}
	}

	void SpawnFood () {
		Vector2 pos = new Vector2(-7 , 0);
		GameObject goodsPrefab = goodFoods [Random.Range(0, goodFoods.Length)];
		Instantiate(goodsPrefab, pos);

	}
	*/

}
