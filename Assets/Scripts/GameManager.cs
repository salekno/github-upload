using System;
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
		SetupGame();
	}

	public void PlayAgain()
	{
		GameObject.Find("GameOver").GetComponent<Canvas>().enabled = false;
		GameObject.Find("GameScreen").GetComponent<Canvas>().enabled = true;
		GameObject.Find("Points").GetComponent<Points>().ResetScore();
		GameObject.Find("EndPoints").GetComponent<Points>().ResetScore();
		cdScript.Init(selectedGameMode);
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
		SetupGame();
	}

	private void SetupGame()
	{
		GameObject.Find("MainMenu").GetComponent<Canvas>().enabled = false;
		GameObject.Find("GameScreen").GetComponent<Canvas>().enabled = true;
		GameObject.Find("Points").GetComponent<Points>().ResetScore();
		GameObject.Find("EndPoints").GetComponent<Points>().ResetScore();
		GameObject.Find("1-1").GetComponent<onClick>().SetGameOver(false);
		timer.GetComponent<Text>().enabled = true;
		cdScript.enabled = true;
		cdScript.Init(selectedGameMode);
	}

	public void SaveHighscore()
	{
		GameObject.Find("EndPoints").GetComponent<Points>().SaveHighscore(selectedGameMode);
	}

	public void DisplayHighscore()
	{
		GameObject.Find("Highscore").GetComponent<Highscore>().DisplayHighscore(selectedGameMode);
	}

	
}
