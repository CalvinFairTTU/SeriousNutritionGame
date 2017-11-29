using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnCard : MonoBehaviour {

    public enum Turns
    {
        PlayerTurn,
        ActiveFromPlayer,
        ComputerTurn,
        ActiveFromComputer
    };

    public GameObject[] foods;
    public GameObject computerSlap;
    public Transform spawnPoint;

    private GameObject tmp;
    private GameObject activeFood;
    private int foodIndex;
    private float timer;
    private Turns turn;

	// Use this for initialization
	void Start ()
    {
        timer = 0f;
        turn = Turns.PlayerTurn;
	}
	
	// Update is called once per frame
	void Update ()
    {
        timer += Time.deltaTime;
        print(timer);

        // Computer's Turn
		if (turn == Turns.ComputerTurn)
        {
            if (activeFood != null)
            {
                Destroy(activeFood);
            }

            timer = 0f;
            SpawnFood();
            turn = Turns.ActiveFromComputer;
            StartCoroutine(Wait());
        }
	}

    void OnMouseDown ()
    {
        // Player's Turn
        if (turn == Turns.PlayerTurn)
        {
            if (activeFood != null)
            {
                    Destroy(activeFood);
            }

            timer = 0f;
            SpawnFood();
            turn = Turns.ActiveFromPlayer;
            StartCoroutine(Wait());
        }
    }

    void SpawnFood ()
    {
        foodIndex = Random.Range(0, 12);
        activeFood = Instantiate(foods[foodIndex], spawnPoint.position, spawnPoint.rotation);
    }

    IEnumerator Wait ()
    {
        if(turn == Turns.ActiveFromPlayer)
        {
            yield return new WaitForSeconds(5f);

            if (activeFood != null)
                StartCoroutine(ComputerSlap());
            else
                turn = Turns.ComputerTurn;
        }
        else if(turn == Turns.ActiveFromComputer)
        {
            turn = Turns.PlayerTurn;

            if (activeFood != null)
                StartCoroutine(ComputerSlap());
        }

        yield return null;
    }

    IEnumerator ComputerSlap ()
    {
        if (Random.Range(0, 3) == 0)
        {
            if (activeFood != null && activeFood.name != "slapped" && timer > 4f)
            {
                tmp = Instantiate(computerSlap, new Vector3(3.89f, 1), activeFood.transform.rotation);
                yield return new WaitForSeconds(1f);
                Destroy(tmp);

                if (activeFood != null)
                {
                    Destroy(activeFood);
                }
            }
        }

        if (turn == Turns.ActiveFromPlayer)
            turn = Turns.ComputerTurn;
    }
}
