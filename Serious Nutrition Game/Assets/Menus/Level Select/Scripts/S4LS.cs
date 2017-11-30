using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class S4LS : MonoBehaviour {

    public void playLevelOne()
    {
		SceneManager.LoadSceneAsync("Level 1");
    }

    public void playLevelTwo()
    {
        SceneManager.LoadSceneAsync("Level2");
    }

    public void playLevelThree()
    {
        SceneManager.LoadSceneAsync("Level3");
    }

    public void back()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }

}
