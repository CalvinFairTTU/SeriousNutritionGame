using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class S3LS : MonoBehaviour {

	public void playLevelOne()
    {
        SceneManager.LoadSceneAsync(8);
    }

    public void playLevelTwo()
    {
        SceneManager.LoadSceneAsync(17);
    }

    public void playLevelThree()
    {
        SceneManager.LoadSceneAsync(18);
    }

    public void back()
    {
        SceneManager.LoadSceneAsync(0);
    }

}
