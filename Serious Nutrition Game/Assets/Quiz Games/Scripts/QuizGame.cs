using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizGame : MonoBehaviour {

	public GameObject foodItemOne;
	public GameObject foodItemTwo;
	public GameObject foodItemThree;
    public Transform quizCanvas;
    public Transform winCanvas;
    public Slider progressBar;
    private bool midGameQuiz;
    private bool endGameQuiz;

    // Use this for initialization
    void Start () {
        midGameQuiz = false;
        endGameQuiz = false;
        StartCoroutine(winGame());
    }
	
	// Update is called once per frame
	void Update () {	
	}

    public void showGameQuiz () {
        // Quiz player at 50% of game completion.
        if((progressBar.value > progressBar.maxValue/2) && midGameQuiz == false)
        {
            Time.timeScale = 0;
            quizCanvas.gameObject.SetActive(true);
        }
        // Quiz player at 100% of game completion.
        if ((progressBar.value == progressBar.maxValue) && endGameQuiz == false)
        {
            Time.timeScale = 0;
            quizCanvas.gameObject.SetActive(true);
        }
    }

	public void firstFoodOption () {
		if (foodItemOne.tag == "Good_Food" && midGameQuiz == false) {
			Debug.Log("Correct food!");
            Time.timeScale = 1;
            quizCanvas.gameObject.SetActive(false);
            midGameQuiz = true;
        }
        else if (foodItemOne.tag == "Good_Food" && endGameQuiz == false)
        {
            Debug.Log("Correct food!");
            Time.timeScale = 1;
            quizCanvas.gameObject.SetActive(false);
            endGameQuiz = true;
        }
        else
        {
            Debug.Log("Wrong food!");
        }
    }

	public void secondFoodOption () {
        if (foodItemOne.tag == "Good_Food" && midGameQuiz == false)
        {
            Debug.Log("Correct food!");
            Time.timeScale = 1;
            quizCanvas.gameObject.SetActive(false);
            midGameQuiz = true;
        }
        else if (foodItemOne.tag == "Good_Food" && endGameQuiz == false)
        {
            Debug.Log("Correct food!");
            Time.timeScale = 1;
            quizCanvas.gameObject.SetActive(false);
            endGameQuiz = true;
        }
        else
        {
            Debug.Log("Wrong food!");
        }
    }

	public void thirdFoodOption () {
        if (foodItemOne.tag == "Good_Food" && midGameQuiz == false)
        {
            Debug.Log("Correct food!");
            Time.timeScale = 1;
            quizCanvas.gameObject.SetActive(false);
            midGameQuiz = true;
        }
        else if (foodItemOne.tag == "Good_Food" && endGameQuiz == false)
        {
            Debug.Log("Correct food!");
            Time.timeScale = 1;
            quizCanvas.gameObject.SetActive(false);
            endGameQuiz = true;
        }
        else
        {
            Debug.Log("Wrong food!");
        }
    }

    IEnumerator winGame()
    {
        yield return new WaitUntil(() => (midGameQuiz == true && endGameQuiz == true));
        winCanvas.gameObject.SetActive(true);
    }

    public void goToMainMenu()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }
}
