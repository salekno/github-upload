﻿using System;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{


	public GameObject timer;
	public Countdown cdScript;
	public string selectedGameMode;
	public void StartSprintMode()
	{
		selectedGameMode = "SprintMode";
		GameObject.Find("MainMenu").GetComponent<Canvas>().enabled = false;
		GameObject.Find("GameScreen").GetComponent<Canvas>().enabled = true;
		GameObject.Find("Points").GetComponent<Points>().ResetScore();
		GameObject.Find("EndPoints").GetComponent<Points>().ResetScore();
		GameObject.Find("1-1").GetComponent<onClick>().SetGameOver(false);
		timer.GetComponent<Text>().enabled = true;
		cdScript.enabled = true;
	}

	public void PlayAgain()
	{
		GameObject.Find("GameOver").GetComponent<Canvas>().enabled = false;
		GameObject.Find("GameScreen").GetComponent<Canvas>().enabled = true;
		GameObject.Find("Points").GetComponent<Points>().ResetScore();
		GameObject.Find("EndPoints").GetComponent<Points>().ResetScore();
		cdScript.enabled = true;
		GameObject.Find("1-1").GetComponent<onClick>().SetGameOver(false);
	}

	public void BackToMenu()
	{
		GameObject.Find("GameOver").GetComponent<Canvas>().enabled = false;
		GameObject.Find("MainMenu").GetComponent<Canvas>().enabled = true;
	}

	public void StartEnduranceMode()
	{
		selectedGameMode = "EnduranceMode";
		GameObject.Find("MainMenu").GetComponent<Canvas>().enabled = false;
		GameObject.Find("GameScreen").GetComponent<Canvas>().enabled = true;
		GameObject.Find("Points").GetComponent<Points>().ResetScore();
		GameObject.Find("EndPoints").GetComponent<Points>().ResetScore();
		GameObject.Find("1-1").GetComponent<onClick>().SetGameOver(false);
		timer.GetComponent<Text>().enabled = true;
		cdScript.enabled = true;
	}

	
}