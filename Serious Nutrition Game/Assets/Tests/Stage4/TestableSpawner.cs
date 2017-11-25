using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestableSpawner : MonoBehaviour {
    //public GameObject[] foods;
    public GameObject food;
    public Vector3 whereToSpawn = new Vector3(-10, 0, 0);
    public float spawnRate = 2f;
    public float nextSpawn = 0.0f;


    // Use this for initialization
    void Start()
    {
        food = null;
    }

    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            food = new GameObject(Time.time.ToString());
            food.transform.position = whereToSpawn;
            Debug.Log("pos = " + food.transform.position);
            //GameObject spanObject = foods[Random.Range(0, foods.Length)];
            //Instantiate(spanObject, whereToSpawn, Quaternion.identity);
        }
    }

}
