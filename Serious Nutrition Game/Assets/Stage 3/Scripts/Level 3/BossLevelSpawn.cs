using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLevelSpawn : MonoBehaviour {

    public GameObject[] foods;
    public GameObject player;
    public GameObject boss;
    public float minRangeSpawn;

    private GameObject SpawnedFood;
    private Vector2 toPlayer, toBoss;
    private float offsetPlayerX, offsetPlayerY, offsetBossX, offsetBossY;

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
                SpawnedFood = Instantiate(foods[Random.Range(0, foods.Length)], transform.position, transform.rotation) as GameObject;
                this.state = Sstates.FOODSPAWNED;
                break;
            case Sstates.FOODSPAWNED:
                if (SpawnedFood.activeSelf == false)
                {
                    Destroy(SpawnedFood);
                    this.state = Sstates.NOFOOD;
                }
                break;
            case Sstates.NOFOOD:
                toPlayer = player.transform.position - transform.position;
                toBoss = boss.transform.position - transform.position;

                offsetPlayerX = Mathf.Abs(toPlayer.x);
                offsetBossX = Mathf.Abs(toBoss.x);

                offsetPlayerY = Mathf.Abs(toPlayer.y);
                offsetBossY = Mathf.Abs(toBoss.y);

                if (offsetPlayerX > offsetBossX && offsetPlayerY > offsetBossY && (toPlayer).magnitude > minRangeSpawn)
                {
                    SpawnedFood = Instantiate(foods[Random.Range(0, foods.Length)], transform.position, transform.rotation) as GameObject;
                    this.state = Sstates.FOODSPAWNED;
                }
                break;
            case Sstates.FINAL:
                if (!SpawnedFood.Equals(null))
                {
                    Destroy(SpawnedFood);
                }
                break;
            default:
                break;
        }
	}    
}
