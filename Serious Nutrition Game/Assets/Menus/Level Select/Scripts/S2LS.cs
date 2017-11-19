using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class S2LS : MonoBehaviour {

    public void playLevelOne()
    {
        SceneManager.LoadSceneAsync("Frog-In-The-Pond");
    }

    public void playLevelTwo()
    {
        SceneManager.LoadSceneAsync("Level 2");
    }

    public void playLevelThree()
    {
        SceneManager.LoadSceneAsync("Level 3");
    }

    public void back()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }

}
