using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S2L1Win : MonoBehaviour {

    public GameObject[] foods;
    public GameObject[] foodsOutLines;
    public GameObject spawnPoint;
    private bool foodAvailable;
    public Slider progressBar;

	// Use this for initialization
	void Start () {
        StartCoroutine(Spawn());
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D food) {
        if (food.transform.localScale == new Vector3(0.4f, 0.4f, 0.4f) && food.tag == "Good_Food") {
			progressBar.value += 0.05f;
			Destroy(food.gameObject);
            foodAvailable = false;
        }

        if (food.transform.localScale == new Vector3(0.2f, 0.2f, 0.2f) && food.tag == "Bad_Food")
        {
            progressBar.value += 0.05f;
            Destroy(food.gameObject);
            foodAvailable = false;
        }
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitUntil(() => foodAvailable == false);
            GameObject food = Instantiate(foods[Random.Range(0, foods.Length)], spawnPoint.transform.position, transform.rotation) as GameObject;
            foodAvailable = true;
        }
    }
}
