﻿using UnityEngine;
using UnityEngine.UI;

public class Highscore : MonoBehaviour {


  private int highscore;
	// Use this for initialization
	void Awake () {
    highscore = PlayerPrefs.GetInt("Highscore");
    this.GetComponent<Text>().text = highscore.ToString();
		Debug.Log("Loaded Highscore");
	}

  public void DisplayHighscore()
  {
	Debug.Log("show highscore");
    highscore = PlayerPrefs.GetInt("Highscore");
    this.GetComponent<Text>().text = "Highscore: " + highscore;
  }
  
	
	// Update is called once per frame
	void Update () {
		
	}
}