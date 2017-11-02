using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLevelSpawn : MonoBehaviour {

    public GameObject[] foods;
    public GameObject player;
    public GameObject boss;

    private GameObject SpawnedFood;
    private float PlayerXoffset, PlayerYoffset;
    private float BossXoffset,BossYoffset;
    private Vector2 toPlayer, toBoss;

    enum Sstates
    {
        INITIAL,
        NOFOOD,
        FOODSPAWNED,
        FINAL
    };

    private Sstates state;

    // Use this for initialization
    void Start ()
    {
        this.state = Sstates.INITIAL;
	}
	
	// Update is called once per frame
	void Update ()
    {
		switch(state)
        {
            case Sstates.INITIAL:
                Debug.Log("state = " + this.state);
                SpawnedFood = Instantiate(foods[Random.Range(0, foods.Length)], transform.position, transform.rotation) as GameObject;
                this.state = Sstates.FOODSPAWNED;
                Debug.Log("state = " + this.state);
                break;
            case Sstates.FOODSPAWNED:
                if (SpawnedFood.activeSelf == false)
                {
                    Destroy(SpawnedFood);
                    this.state = Sstates.NOFOOD;
                    Debug.Log("state = " + this.state);
                }
                break;
            case Sstates.NOFOOD:
                toPlayer = player.transform.position;
                toBoss = boss.transform.position;

                break;
            case Sstates.FINAL:
                break;
            default:
                break;
        }
	}
}
