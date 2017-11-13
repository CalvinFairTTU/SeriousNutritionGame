using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnCard : MonoBehaviour {
    public GameObject[] foods;
    public Transform spawnPoint;
    public GameObject computerSlap;
    public AudioClip goodSound;
    public AudioClip badSound;

    private GameObject tmp;
    private AudioSource gameAudio;
    private float progressPoints;
    private Slider progressBar;
    private int foodIndex;
    private GameObject activeFood;

    public enum Turns
    {
        PlayerTurn,
        ActiveFromPlayer,
        ComputerTurn,
        ActiveFromComputer
    };

    private Turns turn;

	// Use this for initialization
	void Start () {
        gameAudio = this.GetComponent<AudioSource>();
        progressBar = Slider.FindObjectOfType<Slider>();
        progressPoints = progressBar.value;
        turn = Turns.PlayerTurn;
	}
	
	// Update is called once per frame
	void Update () {
		if (turn == Turns.ComputerTurn)
        {
            if (activeFood != null)
            {
                Destroy(activeFood);
            }

            SpawnFood();
            turn = Turns.ActiveFromComputer;
            StartCoroutine(Wait());
        }
	}

    void OnMouseDown ()
    {
        if (turn == Turns.PlayerTurn)
        {
            if (activeFood != null)
            {
                    Destroy(activeFood);
            }

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

            if(activeFood != null)
                Destroy(activeFood);
        }
        else if(turn == Turns.ActiveFromComputer)
        {
            turn = Turns.PlayerTurn;
            yield return new WaitForSeconds(5f);

            if (activeFood != null)
                StartCoroutine(ComputerSlap());
        }

        yield return null;
    }

    IEnumerator ComputerSlap ()
    {
        if (Random.Range(0, 3) == 0)
        {
            if (activeFood != null && activeFood.name != "slapped")
            {
                tmp = Instantiate(computerSlap, new Vector3(3.89f, 1), activeFood.transform.rotation);
                yield return new WaitForSeconds(1f);
                Destroy(tmp);

                if (activeFood != null && activeFood.tag == "GoodFood")
                {
                    gameAudio.clip = badSound;

                    if (progressPoints > 0f)
                        progressPoints -= 0.10f;
                }
                else if (activeFood != null &&  activeFood.tag == "BadFood")
                {
                    gameAudio.clip = goodSound;

                    if (progressPoints < 1f)
                        progressPoints += 0.10f;
                }

                if (activeFood != null)
                {
                    Destroy(activeFood);
                }

                gameAudio.Play();
            }
        }

        if (turn == Turns.ActiveFromPlayer)
            turn = Turns.ComputerTurn;
    }
}
