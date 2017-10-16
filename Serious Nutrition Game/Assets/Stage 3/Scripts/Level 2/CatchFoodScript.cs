using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchFoodScript : MonoBehaviour {

    public GameObject Counter;
    private SpawnCounterScript script;

    private void Start()
    {
        script = Counter.GetComponent<SpawnCounterScript>();
    }

    private void OnTriggerStay2D(Collider2D food)
    {
        food.gameObject.SetActive(false);
        script.DecrementCounter(food,"catchBox");
    }
}
