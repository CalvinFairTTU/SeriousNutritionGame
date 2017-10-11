using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinGame : MonoBehaviour 
{
	public Image winStar;
	public GameObject fireworks;


	void Start() 
	{
		winStar.color = Color.white;
		fireworks.SetActive (false);
	}

	public void Win() 
	{
		winStar.color = Color.yellow;
		fireworks.SetActive(true);
	}
}
