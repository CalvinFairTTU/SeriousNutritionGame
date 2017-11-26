using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class S3LS : MonoBehaviour {

	public void playLevelOne()
    {
        SceneManager.LoadSceneAsync("Frog-In-The-Pond");
    }

    public void playLevelTwo()
    {
        SceneManager.LoadSceneAsync("Meat-Market-Sort");
    }

    public void playLevelThree()
    {
        SceneManager.LoadSceneAsync("Boss-Level");
    }

    public void back()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }

}
