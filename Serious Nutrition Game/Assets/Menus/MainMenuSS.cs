using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuSS : MonoBehaviour {

	public void LoadStageOne()
    {
        SceneManager.LoadSceneAsync("S1LS");
    }

    public void LoadStageTwo()
    {
        SceneManager.LoadSceneAsync("S2LS");
    }

    public void LoadStageThree()
    {
        SceneManager.LoadSceneAsync("S3LS");
    }

    public void LoadStageFour()
    {
        SceneManager.LoadSceneAsync("S4LS");
    }

    public void LoadStageFive()
    {
        SceneManager.LoadSceneAsync("S5LS");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
