using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class MeatMarketSpawnScript : MonoBehaviour
{

    public GameObject[] foods;
    //public Slider progressBar;
    //private float progressPoints;
    public GameObject Counter;
    private SpawnCounterScript counterScript;


    private GameObject SpawnedFood;
    private int counterCheck;


    enum Mstates
    {
        INITIAL,
        NOFOOD,
        FOODSPAWNED,
        FOODSPAWNED_PRE,
        FINAL
    };

    private Mstates state;

    // Use this for initialization
    void Start()
    {
        counterScript = Counter.GetComponent<SpawnCounterScript>();
        state = Mstates.INITIAL;
        
        //progressPoints = progressBar.value;
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
                  
                //if (progressPoints >= 1f)
                //{
                //    state = Mstates.FINAL;
                //}
                break;

            case Mstates.FOODSPAWNED:
                if (SpawnedFood.activeSelf == false)
                {
                    Destroy(SpawnedFood);
                    state = Mstates.NOFOOD;
                }
                
                //if (progressPoints >= 1f)
                //{
                //    state = Mstates.FINAL;
                //}
                break;

            case Mstates.NOFOOD:

                counterCheck = counterScript.GetCounter();
                Debug.Log("counterCheck in " + this + " = " + counterCheck);
                if (counterCheck == 0)
                {
                    SpawnedFood = Instantiate(foods[Random.Range(0, foods.Length)], transform.position, transform.rotation) as GameObject;
                    Debug.Log("****************************************************************************FOOD SPAWNED IN " + this);
                    state = Mstates.FOODSPAWNED_PRE;
                }
                
                //if (progressPoints >= 1f)
                //{
                //    state = Mstates.FINAL;
                //}
                break;

            case Mstates.FOODSPAWNED_PRE:

                counterScript.IncrementCounter();
                state = Mstates.FOODSPAWNED;
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
