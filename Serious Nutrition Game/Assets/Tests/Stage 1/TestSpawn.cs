using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpawn : MonoBehaviour
{
    //public GameObject[] foods;
    public GameObject food;
    public float dropSpeed;
    public float minSpawnTime = 1.5f;
    public float maxSpawnTime = 3f;

    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));
            //GameObject food = Instantiate(foods[Random.Range(0, foods.Length)], transform.position, transform.rotation) as GameObject;
            food = new GameObject("foodItem");
        }
    }
}
