using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TestablePondSpawnPoint : MonoBehaviour {

    public class TimerData
    {
        private int WaitCyclesSpawn, WaitCyclesDestroy, initialWait, WaitCyclesBubbling, minWaitSpawn, maxWaitSpawn;
        private int cycleCounter;

        public TimerData(int minWaitSpawn, int maxWaitSpawn, int minWaitDestroy, int maxWaitDestroy, int initialWaitRange, int minWaitBubbling, int maxWaitBubbling)
        {
            this.minWaitSpawn = minWaitSpawn; this.maxWaitSpawn = maxWaitSpawn;
            WaitCyclesSpawn = Random.Range(minWaitSpawn, maxWaitSpawn + 1);
            WaitCyclesDestroy = Random.Range(minWaitDestroy, maxWaitDestroy + 1);
            initialWait = Random.Range(1, initialWaitRange + 1);
            WaitCyclesBubbling = Random.Range(minWaitBubbling, maxWaitBubbling + 1);
            cycleCounter = 0;
        }

        public int getCycleCounter() { return cycleCounter;  }
        public void resetCycleCounter() { this.cycleCounter = 0;  }
        public void incrementCycleCounter() { this.cycleCounter += 1; }

        public int getWaitCycleSpawn() { return this.WaitCyclesSpawn;  }
        public int getWaitCyclesDestroy() {  return this.WaitCyclesDestroy; }
        public int getInitialWait() { return this.initialWait; }
        public int getWaitCyclesBubbling() { return this.WaitCyclesBubbling; }
        public int getMinWaitCycleSpawn() { return this.minWaitSpawn; }
        public int getMaxWaitCycleSpawn() { return this.maxWaitSpawn;  }
    }



    public GameObject[] foods;
    public TimerData timer;
    //public Slider progressBar;
    //public GameObject player;
    //public float minSpawnRange;
    //public GameObject Bubbler;

    private float progressPoints;
    //private GameObject SpawnedFood;
    private bool SpawnedFood;
    //private Vector2 trackPlayer;
    //private float hypotenuse;
    //private Animator Anim;

    public enum Mstates
    {
        INITIAL,
        NOFOOD,
        BUBBLING,
        FOODSPAWNED,
        FINAL
    };

    public Mstates state;

    
    // Use this for initialization
    void Start()
    {
        state = Mstates.INITIAL;
        timer = new TimerData(10,50,50,80,10,20,30);       
        progressPoints = 0;
        //Anim = Bubbler.GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        //progressPoints = progressBar.value;
        switch (state)
        {
            case Mstates.INITIAL:
                if (timer.getCycleCounter() < timer.getInitialWait())
                {
                    timer.incrementCycleCounter();
                }
                else
                {
                    state = Mstates.BUBBLING;
                    timer.resetCycleCounter();
                    //Anim.SetInteger("Ripple", 1);
                }
                if (progressPoints >= 1f)
                {
                    state = Mstates.FINAL;
                }
                break;

            case Mstates.FOODSPAWNED:
                if (SpawnedFood/*.activeSelf*/ == false)
                {
                    //Destroy(SpawnedFood);
                    timer.resetCycleCounter();
                    state = Mstates.NOFOOD;
                }
                else if (timer.getCycleCounter() < timer.getWaitCyclesDestroy())
                {
                    timer.incrementCycleCounter();
                }
                else
                {
                    //Destroy(SpawnedFood);
                    timer.resetCycleCounter();
                    state = Mstates.NOFOOD;
                }
                if (progressPoints >= 1f)
                {
                    state = Mstates.FINAL;
                }
                break;

            case Mstates.BUBBLING:
                if (timer.getCycleCounter() < timer.getWaitCyclesBubbling())
                {
                    timer.incrementCycleCounter();
                }
                else
                {
                    //Anim.SetInteger("Ripple", 0);
                    SpawnedFood = setSpawnedFood(true)/*Instantiate(foods[Random.Range(0, foods.Length)], transform.position, transform.rotation) as GameObject*/;
                    state = Mstates.FOODSPAWNED;
                    timer.resetCycleCounter();
                }
                if (progressPoints >= 1f)
                {
                    state = Mstates.FINAL;
                }
                break;

            case Mstates.NOFOOD:
                //trackPlayer = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);
                //hypotenuse = Mathf.Sqrt((trackPlayer.x * trackPlayer.x) + (trackPlayer.y * trackPlayer.y));
                if (timer.getCycleCounter() < timer.getWaitCyclesDestroy()/* && hypotenuse >= minSpawnRange*/)
                {
                    timer.incrementCycleCounter();
                }
                else if (timer.getCycleCounter() >= timer.getWaitCycleSpawn())
                {
                    //Anim.SetInteger("Ripple", 1);
                    state = Mstates.BUBBLING;
                    timer.resetCycleCounter();
                }
                if (progressPoints >= 1f)
                {
                    state = Mstates.FINAL;
                }
                break;

            case Mstates.FINAL:
                if (!SpawnedFood/*.Equals(null)*/)
                {
                    //Destroy(SpawnedFood);
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
        return (int)Random.Range(lowerBound, upperBound);
    }

    public bool getSpawnedFood()
    {
        return this.SpawnedFood;
    }
    public bool setSpawnedFood(bool value)
    {
        return value;
    }
    
}
