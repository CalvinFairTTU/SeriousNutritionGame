using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour {
    // Spawn settings.
    public Transform[] spawnLocation;
    public GameObject[] good_food;
    public GameObject[] bad_food;
    public GameObject[] foodToSpawn;
    
    void Start() {
        spawnFruit();
    }

    void spawnFruit() {
        while (true)
        {
            for (int x = 0; x < good_food.Length; x++)
            {
                foodToSpawn[x] = Instantiate(good_food[x], spawnLocation[x].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
            }
            foodToSpawn[3] = Instantiate(bad_food[0], spawnLocation[2].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
        }
    }
}
