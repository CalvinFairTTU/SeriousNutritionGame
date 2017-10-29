using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FridgeSpawn : MonoBehaviour {
    // Spawn settings.
    public Transform[] spawn_location;
    public GameObject[] good_foods;
    public GameObject[] bad_foods;
    public GameObject[] food_To_Spawn;

    //int score = 0;

    void Start() {
        spawnFruit();

    }

    void spawnFruit() {
        for (int x = 0; x < good_foods.Length; x++)
           {

                food_To_Spawn[x] = Instantiate(good_foods[x], spawn_location[x].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
            }
       //while (true)
       //{
          //for (int x = 0; x < good_foods.Length; x++)
          // {
          //     food_To_Spawn[x] = Instantiate(good_foods[x], spawn_location[x].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
          //  }
          //  food_To_Spawn[3] = Instantiate(bad_foods[0], spawn_location[2].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
        }
    }
//}
