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
            foodIndex = Random.Range(0, 12);
            activeFood = Instantiate(foods[foodIndex], spawnPoint.position, spawnPoint.rotation);
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

            foodIndex = Random.Range(0, 12);
            activeFood = Instantiate(foods[foodIndex], spawnPoint.position, spawnPoint.rotation);
            turn = Turns.ActiveFromPlayer;
            StartCoroutine(Wait());
        }
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
            yield return new WaitForSeconds(2f);

            if (activeFood != null)
                StartCoroutine(ComputerSlap());
            
            turn = Turns.PlayerTurn;
        }

        yield return null;
    }

    IEnumerator ComputerSlap ()
    {
        if (Random.Range(0, 3) == 0)
        {
            if (activeFood != null)
            {
                tmp = Instantiate(computerSlap, new Vector3(3.89f, 1), activeFood.transform.rotation);
                yield return new WaitForSeconds(1f);
                Destroy(tmp);

                yield return new WaitForSeconds(2f);
                if(activeFood != null)
                    Destroy(activeFood);

                if (activeFood.tag == "GoodFood")
                {
                    gameAudio.clip = badSound;

                    if (progressPoints > 0f)
                        progressPoints -= 0.05f;
                }
                else if (activeFood.tag == "BadFood")
                {
                    gameAudio.clip = goodSound;

                    if (progressPoints < 1f)
                        progressPoints += 0.05f;
                }

                gameAudio.Play();
            }
        }

        if (turn == Turns.ActiveFromPlayer)
            turn = Turns.ComputerTurn;
    }
}
