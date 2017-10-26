using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour {

    public bool paused;
	public Transform canvas;
    
	void Start () {
        paused = false;
	}

	public void pauseGame () {
        paused = !paused;

        if (paused)
        {
			canvas.gameObject.SetActive (true);
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
			canvas.gameObject.SetActive (false);
        }
    }

    public void exitGame () {
        SceneManager.LoadScene(0);
		Time.timeScale = 1;
    }

    public void openSettings() {

    }
}
