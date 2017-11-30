using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class PondSpawnPointFood : MonoBehaviour {

    public GameObject[] foods;
    public int minWaitSpawn, maxWaitSpawn, minWaitDestroy, maxWaitDestroy, initialWaitRange;
    public Slider progressBar;
    public GameObject player;
    public float minSpawnRange;
    public GameObject Bubbler;

    private float progressPoints;
    private int WaitCyclesSpawn, WaitCyclesDestroy, initialWait, WaitCyclesBubbling;
    private GameObject SpawnedFood;
    private int cycleCounter;
    private Vector2 trackPlayer;
    private float hypotenuse;
    private Animator Anim;

    enum Mstates
    {
        INITIAL,
        NOFOOD,
        BUBBLING,
        FOODSPAWNED,
        FINAL
    };

    private Mstates state;

    // Use this for initialization
    void Start ()
    {
        state = Mstates.INITIAL;
        cycleCounter = 0;
        initialWait = GetValueFromRange(100, initialWaitRange);
        WaitCyclesSpawn = GetValueFromRange(minWaitSpawn, maxWaitSpawn + 1);
        WaitCyclesDestroy = GetValueFromRange(minWaitDestroy, maxWaitDestroy + 1);
        WaitCyclesBubbling = GetValueFromRange(100, 200 + 1);
        progressPoints = progressBar.value;
        Anim = Bubbler.GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        progressPoints = progressBar.value;
        switch (state)
        {
            case Mstates.INITIAL:
                if (cycleCounter < initialWait)
                {
                    cycleCounter++;
                }
                else
                {
                    state = Mstates.BUBBLING;
                    cycleCounter = 0;
                    Anim.SetInteger("Ripple", 1);
                }
                if (progressPoints >= 1f)
                {
                    state = Mstates.FINAL;
                }
                break;

            case Mstates.FOODSPAWNED:
                if (SpawnedFood.activeSelf == false)
                {
                    Destroy(SpawnedFood);
                    cycleCounter = 0;
                    state = Mstates.NOFOOD;
                }
                else if (cycleCounter < WaitCyclesDestroy)
                {
                    cycleCounter++;
                }
                else
                {
                    Destroy(SpawnedFood);
                    cycleCounter = 0;
                    state = Mstates.NOFOOD;
                }
                if (progressPoints >= 1f)
                {
                    state = Mstates.FINAL;
                }
                break;

            case Mstates.BUBBLING:
                if (cycleCounter < WaitCyclesBubbling)
                {
                    cycleCounter++;
                }
                else
                {
                    Anim.SetInteger("Ripple", 0);
                    SpawnedFood = Instantiate(foods[Random.Range(0, foods.Length)], transform.position, transform.rotation) as GameObject;
                    state = Mstates.FOODSPAWNED;
                    cycleCounter = 0;
                }
                if (progressPoints >= 1f)
                {
                    state = Mstates.FINAL;
                }
                break;

            case Mstates.NOFOOD:
                trackPlayer = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);
                hypotenuse = Mathf.Sqrt((trackPlayer.x * trackPlayer.x) + (trackPlayer.y * trackPlayer.y));
                if (cycleCounter < WaitCyclesSpawn && hypotenuse >= minSpawnRange)
                {
                    cycleCounter++;
                }
                else if (cycleCounter >= minWaitSpawn)
                {
                    Anim.SetInteger("Ripple", 1);
                    state = Mstates.BUBBLING;
                    cycleCounter = 0;
                }
                if (progressPoints >= 1f)
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

    int GetValueFromRange(int lowerBound, int upperBound)
    {
        return (int)Random.Range(lowerBound, upperBound); ;
    }
}


