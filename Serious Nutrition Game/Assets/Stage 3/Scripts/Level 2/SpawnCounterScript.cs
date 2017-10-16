using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class SpawnCounterScript : MonoBehaviour {

    private int destCounter;   
    private float progressPoints;
    public Slider ProgressBar;

    AudioSource gameAudio;
    public AudioClip goodSound;
    public AudioClip badSound;
    

	// Use this for initialization
	void Start ()
    {
        this.destCounter = 0;
        progressPoints = 0f;
        ProgressBar.value = progressPoints;
        gameAudio = gameObject.GetComponent<AudioSource>();
    }
	
	public int GetCounter()
    {
        return this.destCounter;
    }

    public void DecrementCounter(Collider2D food,string box)
    {
        this.destCounter -= 1;
        Debug.Log("DecrementCounter() destCounter = " + this.destCounter + " on " + box);
        switch (box)
        {
            case "catchBox":
                gameAudio.volume = 0.8f;
                gameAudio.clip = badSound;
                progressPoints -= 0.05f;
                break;
            case "goodBox":
                if (food.tag == "Good_Food")
                {
                    gameAudio.volume = 0.8f;
                    gameAudio.clip = goodSound;
                    progressPoints += 0.05f;
                }
                else if (food.tag == "Bad_Food")
                {
                    gameAudio.volume = 0.8f;
                    gameAudio.clip = badSound;
                    progressPoints -= 0.05f;
                }
                break;
            case "badBox":
                if (food.tag == "Good_Food")
                {
                    gameAudio.volume = 0.8f;
                    gameAudio.clip = badSound;
                    progressPoints -= 0.05f;
                }
                else if (food.tag == "Bad_Food")
                {
                    gameAudio.volume = 0.8f;
                    gameAudio.clip = goodSound;
                    progressPoints += 0.05f;
                }
                break;
            default:
                break;
        }
        Debug.Log("progressPoints = " + progressPoints);
        ProgressBar.value = progressPoints;
    }

    public void IncrementCounter()
    {
        this.destCounter += 1;
        Debug.Log("IncrementCounter() destCounter = " + this.destCounter);
    }

    public void SetCounter(int target)
    {
        this.destCounter = target;
        Debug.Log("SetCounter(" + target + ") destCounter = " + this.destCounter);        
    }
    
    public float GetPoints()
    {
        return this.progressPoints;
    }

    void LateUpdate()
    {
        if (progressPoints >= 1)
        {
            Debug.Log("VICTORY!!!!!!!!!!!!!!");
        }
    }
}
