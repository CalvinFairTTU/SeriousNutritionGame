using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CarEats : MonoBehaviour {

    public Slider progressBar;
    public GameObject boss;
    public int waitExit;

    private float progressPoints;
    private Transform BossTransform;
    private int cycleCounter;
    private Vector3 scaleTracker;

	// Use this for initialization
	void Start ()
    {
        progressPoints = 0f;
        Debug.Log("progressPoints = " + progressPoints);
        cycleCounter = 0;
        BossTransform = boss.GetComponent<Transform>();
        scaleTracker = BossTransform.localScale;
        Debug.Log("ScaleTracker = " + scaleTracker);
    }

    // Update is called once per frame
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "BadFood")
        {
            if (progressPoints > 0f)
            {
                progressPoints -= 0.05f;
            }
            else if (progressPoints < 0f)
            {
                progressPoints = 0f;
            }
            Debug.Log("progressPoints = " + progressPoints);
        }
        else if (col.tag == "GoodFood")
        {
            progressPoints += 0.05f;
            Debug.Log("progressPoints = " + progressPoints);
            col.gameObject.SetActive(false);
            if (scaleTracker.x > 0.2)
            {
                BossTransform.localScale -= new Vector3(0.1f, 0.1f, 0);
                scaleTracker = BossTransform.localScale;
            }
            Debug.Log("ScaleTracker = " + scaleTracker);
        }
        progressBar.value = progressPoints;
    }

    private void LateUpdate()
    {
        if (progressPoints >= 1f && cycleCounter >= waitExit)
        {            
            SceneManager.LoadSceneAsync(3);
        }
        else if (progressPoints >= 1f)
        {
            cycleCounter++;
        }
    }
}
