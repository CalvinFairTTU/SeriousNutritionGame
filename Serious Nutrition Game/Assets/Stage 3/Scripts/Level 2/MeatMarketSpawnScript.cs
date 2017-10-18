using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class MeatMarketSpawnScript : MonoBehaviour
{

    public GameObject[] foods;
    public GameObject Counter;
    private SpawnCounterScript counterScript;


    private GameObject SpawnedFood;
    private int counterCheck;


    enum Mstates
    {
        INITIAL,
        NOFOOD,
        FOODSPAWNED,
        FOODSPAWNED_DELAY,
        FOODSPAWNED_INC,
        FINAL
    };

    private Mstates state;

    // Use this for initialization
    void Start()
    {
        counterScript = Counter.GetComponent<SpawnCounterScript>();
        state = Mstates.INITIAL;
    }

    private void FixedUpdate()
    {
        //progressPoints = progressBar.value;
        switch (state)
        {
            case Mstates.INITIAL:
                
                SpawnedFood = Instantiate(foods[Random.Range(0, foods.Length)], transform.position, transform.rotation) as GameObject;
                state = Mstates.FOODSPAWNED;
                counterScript.IncrementCounter();

                if (counterScript.GetPoints() >= 1f)
                {
                    state = Mstates.FINAL;
                }
                break;

            case Mstates.FOODSPAWNED:

                if (SpawnedFood.activeSelf == false)
                {
                    Destroy(SpawnedFood);
                    state = Mstates.NOFOOD;
                }

                if (counterScript.GetPoints() >= 1f)
                {
                    state = Mstates.FINAL;
                }
                break;

            case Mstates.NOFOOD:

                counterCheck = counterScript.GetCounter();
                if (counterCheck == 0)
                {
                    SpawnedFood = Instantiate(foods[Random.Range(0, foods.Length)], transform.position, transform.rotation) as GameObject;
                    state = Mstates.FOODSPAWNED_DELAY;
                }

                if (counterScript.GetPoints() >= 1f)
                {
                    state = Mstates.FINAL;
                }
                break;

            case Mstates.FOODSPAWNED_DELAY:

                state = Mstates.FOODSPAWNED_INC; // Delay for one cycle so that all the SpawnPoints can pick up the counter and spawn food.

                if (counterScript.GetPoints() >= 1f)
                {
                    state = Mstates.FINAL;
                }
                break;

            case Mstates.FOODSPAWNED_INC:

                counterScript.IncrementCounter(); // Increment the counter to account for the newly spawned food object.
                state = Mstates.FOODSPAWNED;

                if (counterScript.GetPoints() >= 1f)
                {
                    state = Mstates.FINAL;
                }
                break;

            case Mstates.FINAL:
                
                if (!SpawnedFood.Equals(null))
                {
                    Destroy(SpawnedFood);
                }
                else
                {
                    ;
                }
                break;

            default:
                break;
        }


    }


}
