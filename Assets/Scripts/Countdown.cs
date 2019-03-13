using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    public Highscore hsScript;

    public Points pointsScript;

    private bool clicked;

    private float timer;
    private int seconds;

    // Use this for initialization
    void Awake()
    {
        seconds = 30;
        timer = 30;
        clicked = false;
        pointsScript = GameObject.Find("Points").GetComponent<Points>();
        this.enabled = false;
        this.GetComponent<Text>().text = seconds.ToString();
    }


    // Update is called once per frame
    void Update()
    {
        if (!clicked)
        {
            return;
        }

        timer -= Time.deltaTime;
        TimerCount((int) (timer % 60) + 1);
        this.GetComponent<Text>().text = seconds.ToString();
        if (timer <= 0)
        {
            GameOver();
        }
    }


    public void GameOver()
    {
        pointsScript.SaveHighscore();
        timer = 30;
        seconds = 30;
        Debug.Log("GameOver");
        hsScript.DisplayHighscore();
        this.clicked = false;
        this.enabled = false;
        this.GetComponent<Text>().text = seconds.ToString();
        this.GetComponent<Text>().color = Color.black;
        this.GetComponentInParent<Canvas>().enabled = false;
        GameObject.Find("GameOver").GetComponent<Canvas>().enabled = true;
        GameObject.Find("PlayAgain").GetComponent<PlayAgain>().enabled = false;
        StartCoroutine(Wait());
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        GameObject.Find("PlayAgain").GetComponent<PlayAgain>().enabled = true;
    }

    public void FirstClicked()
    {
        this.clicked = true;
    }

    private void TimerCount(int time)
    {
        if (time <= 5)
        {
            this.GetComponent<Text>().color = Color.red;
        }

        seconds = time;
    }
}