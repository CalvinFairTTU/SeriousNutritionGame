using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestableSpawnScript : MonoBehaviour {

    //public GameObject[] foods;
    public GameObject[] spawns;
    public GameObject TheNewObject;

    public int foodIndex;
    public int spawnIndex;
    public bool objectCreated;
    public int i,x,y,chosenIndex;

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("SpawnFood", 3f, 7f);
        Array.Resize(ref spawns, 4);
        x = 0;
        y = 0;
        for(i = 0; i < 4; i++)
        {
            spawns[i] = new GameObject(i.ToString());
            spawns[i].transform.position = new Vector3(x,y,0);
            x++;
            y++;
        }
        objectCreated = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnFood()
    {
        foodIndex = UnityEngine.Random.Range(0, 6);
        spawnIndex = UnityEngine.Random.Range(0, 4);
        objectCreated = true;
        TheNewObject = new GameObject();
        TheNewObject.transform.position = new Vector3(spawns[spawnIndex].transform.position.x, spawns[spawnIndex].transform.position.y, spawns[spawnIndex].transform.position.z);
        //Instantiate(foods[foodIndex], spawns[spawnIndex].position, spawns[spawnIndex].rotation);
    }

    public int ChooseIndex(int x) { return x; }
}
