using System;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour {


  private int score;

  // Use this for initialization
  void Awake () {
    this.GetComponent<Text>().text = score.ToString();
  }
	
	// Update is called once per frame
	void Update () {
		
	}

  public void IncreaseScore()
  {
    score++;
    this.GetComponent<Text>().text = score.ToString();
  }

  public void ResetScore()
  {
    Debug.Log(string.Format("Reset score{0} to Zero - {1}", score, ToString()));
    score = 0;
    this.GetComponent<Text>().text = score.ToString();
  }

  public void SaveHighscore()
  {
    if(score > PlayerPrefs.GetInt("Highscore"))
    {
      Debug.Log("Saved Highscore " + score);
      PlayerPrefs.SetInt("Highscore", score);
    }
    
  }
}
