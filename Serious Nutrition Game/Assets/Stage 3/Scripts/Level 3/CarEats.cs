﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CarEats : MonoBehaviour {

    public Slider progressBar;
    public GameObject boss;
    public int waitExit, BumpWait;
    public AudioClip GoodSound,BadSound;
    
    private float progressPoints;
    private Transform BossTransform;
    private int cycleCounter,bumpCycleCounter;
    private Vector3 scaleTracker;
    private AudioSource Audio;

    // Use this for initialization
    void Start ()
    {
        progressPoints = 0f;
        cycleCounter = 0;
        BossTransform = boss.GetComponent<Transform>();
        scaleTracker = BossTransform.localScale;
        Audio = gameObject.GetComponent<AudioSource>();
        bumpCycleCounter = 0;
    }

    // Update is called once per frame
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "BadFood")
        {
            if (bumpCycleCounter == 0)
            {
                if (progressPoints > 0f)
                {
                    Audio.volume = 0.8f;
                    Audio.clip = BadSound;
                    progressPoints -= 0.05f;
                }
                else if (progressPoints < 0f)
                {
                    progressPoints = 0f;
                }
                Audio.Play();
                bumpCycleCounter = BumpWait;
            }
            else
            {
                bumpCycleCounter--;
            }
            
        }
        else if (col.tag == "GoodFood")
        {
            Audio.volume = 0.8f;
            Audio.clip = GoodSound;
            progressPoints += 0.05f;
            col.gameObject.SetActive(false);
            if (scaleTracker.x > 0.2)
            {
                BossTransform.localScale -= new Vector3(0.1f, 0.1f, 0);
                scaleTracker = BossTransform.localScale;
            }
            Audio.Play();
            bumpCycleCounter = 0;
        }
        progressBar.value = progressPoints;
    }

    private void LateUpdate()
    {
        if (progressPoints >= 1f && cycleCounter >= waitExit)
        {            
            //SceneManager.LoadSceneAsync("S3LS");
        }
        else if (progressPoints >= 1f)
        {
            cycleCounter++;
        }
    }
}
