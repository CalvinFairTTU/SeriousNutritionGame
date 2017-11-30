using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class SpawnCounterScript : MonoBehaviour {
    
    public Slider ProgressBar;
    public AudioSource gameAudio;
    public AudioClip goodSound;
    public AudioClip badSound;
    public int waitExitCycles;
    

    private int destCounter;
    private float progressPoints;
    private int exitCounter;



    // Use this for initialization
    void Start ()
    {
        this.destCounter = 0;
        progressPoints = 0f;
        ProgressBar.value = progressPoints;
        exitCounter = 0;
    }
	
	public int GetCounter()
    {
        return this.destCounter;
    }

    public void DecrementCounter(Collider2D food,string box,string boxTag)
    {
        this.destCounter -= 1;
        switch (box)
        {
            case "catchBox":
                gameAudio.volume = 0.8f;
                gameAudio.clip = badSound;
                gameAudio.Play();
                if (progressPoints > 0f)
                {
                   progressPoints -= 0.05f;
                }
                break;
            case "goodBox":
                if (boxTag == food.tag)
                {
                    gameAudio.volume = 0.8f;
                    gameAudio.clip = goodSound;
                    gameAudio.Play();
                    progressPoints += 0.05f;
                }
                else
                {
                    gameAudio.volume = 0.8f;
                    gameAudio.clip = badSound;
                    gameAudio.Play();
                    if (progressPoints > 0f)
                    {
                        progressPoints -= 0.05f;
                    }
                }
                break;            
            case "badBox":
                if (food.tag != "Bad_Food")
                {
                    gameAudio.volume = 0.8f;
                    gameAudio.clip = badSound;
                    gameAudio.Play();
                    if (progressPoints > 0f)
                    {
                        progressPoints -= 0.05f;
                    }
                }
                else
                {
                    gameAudio.volume = 0.8f;
                    gameAudio.clip = goodSound;
                    gameAudio.Play();
                    progressPoints += 0.05f;
                }
                break;
            default:
                break;
        }
        ProgressBar.value = progressPoints;
    }

    public void IncrementCounter()
    {
        this.destCounter += 1;
    }

    public void SetCounter(int target)
    {
        this.destCounter = target;     
    }
    
    public float GetPoints()
    {
        return this.progressPoints;
    }

    void LateUpdate()
    {
        if (progressPoints >= 1 && exitCounter < waitExitCycles)
        {
            exitCounter++;
        }
        else if (progressPoints >= 1 && exitCounter >= waitExitCycles)
        {
            //SceneManager.LoadSceneAsync("S3LS");
        }
    }
}
