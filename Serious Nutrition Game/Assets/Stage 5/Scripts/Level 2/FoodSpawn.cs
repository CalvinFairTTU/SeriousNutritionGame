using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawn : MonoBehaviour {
    public GameObject[] foods;
    public Transform[] spawns;
    
    private int foodIndex;
    private int spawnIndex;

	// Use this for initialization
	void Start ()
    {
        InvokeRepeating("SpawnFood", 3f, 7f);
    }
	
	// Update is called once per frame
	void Update ()
    {
        
    }

    void SpawnFood ()
    {
        foodIndex = Random.Range(0, 6);
        spawnIndex = Random.Range(0, 4);
        Instantiate(foods[foodIndex], spawns[spawnIndex].position, spawns[spawnIndex].rotation);
    }
}
