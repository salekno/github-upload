﻿using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    public Highscore hsScript;

    public Points pointsScript;

    private bool clicked;

    private double timer;
    private int seconds;
    private double timerIncrement;

    // Use this for initialization
    void Awake()
    {
        timerIncrement = 1;
        clicked = false;
        pointsScript = GameObject.Find("Points").GetComponent<Points>();
        this.enabled = false;
        this.GetComponent<Text>().text = seconds.ToString();
        Debug.Log("Set seconds to " + seconds.ToString());
    }

    private void OnEnable()
    {
        timerIncrement = 1;
        clicked = false;
        pointsScript = GameObject.Find("Points").GetComponent<Points>();
    }

    public void Init(string gameMode)
    {
        switch (gameMode)
        {
            case "SprintMode": SetupSprintMode();
                break;
            case "EnduranceMode": SetupEnduranceMode();
                break;
            default: //TODO setup default mode?
                break;
        }
        this.GetComponent<Text>().text = seconds.ToString();
        Debug.Log("Set seconds to " + seconds.ToString());
        Debug.Log("Init with gameMode " + gameMode);
    }

    private void SetupSprintMode()
    {
        seconds = 30;
        timer = 30;
    }

    private void SetupEnduranceMode()
    {
        seconds = 10;
        timer = 10;
    }


    // Update is called once per frame
    void Update()
    {
        if (!clicked)
        {
            return;
        }

        timer -= Time.deltaTime;
        UpdateSeconds((int) (timer % 60) + 1);
        this.GetComponent<Text>().text = seconds.ToString();
        if (timer <= 0)
        {
            GameOver();
        }
    }

    public void UpdateTimer(string gameMode, int score)
    {
        switch (gameMode)
        {
            case "EnduranceMode":
                if (score % 5 == 0 && score != 0)
                {
                    this.timer += timerIncrement;
                    Debug.Log(string.Format("Increased Timer({0}) by {1}", this.timer, timerIncrement));
                    timerIncrement *= 0.95;
                }

                break;
        }
    }


    public void GameOver()
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().SaveHighscore();
        Debug.Log("GameOver");
        GameObject.Find("GameManager").GetComponent<GameManager>().DisplayHighscore();
        this.clicked = false;
        this.enabled = false;
        this.GetComponent<Text>().text = seconds.ToString();
        this.GetComponent<Text>().color = Color.black;
        this.GetComponentInParent<Canvas>().enabled = false;
        GameObject.Find("GameOver").GetComponent<Canvas>().enabled = true;
        GameObject.Find("PlayAgain").GetComponent<PlayAgain>().enabled = false;
        GameObject.Find("BackToMenu").GetComponent<BackToMenu>().enabled = false;
        StartCoroutine(Wait());
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        GameObject.Find("PlayAgain").GetComponent<PlayAgain>().enabled = true;
        GameObject.Find("BackToMenu").GetComponent<BackToMenu>().enabled = true;
    }

    public void FirstClicked()
    {
        this.clicked = true;
    }

    private void UpdateSeconds(int time)
    {
        if (time <= 5)
        {
            this.GetComponent<Text>().color = Color.red;
        }

        seconds = time;
    }
}