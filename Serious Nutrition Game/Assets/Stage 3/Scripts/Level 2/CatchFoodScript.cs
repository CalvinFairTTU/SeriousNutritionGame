using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchFoodScript : MonoBehaviour {

    public GameObject Counter;

    private void OnTriggerStay2D(Collider2D food)
    {
        food.gameObject.SetActive(false);
        Counter.GetComponent<SpawnCounterScript>().DecrementCounter();
    }
}
