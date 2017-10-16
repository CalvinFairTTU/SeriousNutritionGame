using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class FrogEat : MonoBehaviour {

    public Slider progressBar;
    public AudioClip goodSound;
    public AudioClip badSound;

    AudioSource gameAudio;

    private float progressPoints;    
   

    // Use this for initialization
    void Start ()
    {
        progressPoints = 0;
        gameAudio = gameObject.GetComponent<AudioSource>();
    }

    void OnTriggerStay2D(Collider2D food)
    {
        if (food.tag == "Good_Food")
        {
            gameAudio.volume = 0.8f;
            gameAudio.clip = goodSound;
            if (progressPoints < 1f)
            {
                progressPoints += 0.05f;
            }
        }
        else
        {
            gameAudio.volume = 0.8f;
            gameAudio.clip = badSound;
            if (progressPoints > 0f)
            {
                progressPoints -= 0.05f;
            }
        }
        gameAudio.Play();
        food.gameObject.SetActive(false);
        progressBar.value = progressPoints;
        if (progressBar.value >= 1f)
        {
            gameObject.GetComponent<FrogWins>().SetVictory();
        }
    }

    
}


