using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class onClick : MonoBehaviour, IPointerClickHandler
{
    public static bool gameOver;
    public ColorManager cmScript;
    public Points pointsScript;
    public Points endPointsScript;

    public Countdown cdScript;
    private string currentGameMode;

    // Use this for initialization
    void Awake()
    {
        gameOver = false;
        cmScript = GameObject.Find("ColorManager").GetComponent<ColorManager>();
        pointsScript = GameObject.Find("Points").GetComponent<Points>();
        cdScript = GameObject.Find("Timer").GetComponent<Countdown>();
        endPointsScript = GameObject.Find("EndPoints").GetComponent<Points>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        currentGameMode = GameObject.Find("GameManager").GetComponent<GameManager>().selectedGameMode;

        GameObject.Find("Timer").GetComponent<Countdown>().FirstClicked();
        if (gameOver)
        {
            return;
        }

        if (this.GetComponent<Image>().color == Color.white)
        {
            StartCoroutine(RedBlink());
        }
        else
        {
            cmScript.makeOneFromRandomRowBlack();
            this.GetComponent<Image>().color = Color.white;
            pointsScript.IncreaseScore();
            endPointsScript.IncreaseScore();
        }
        
        cdScript.UpdateTimer(currentGameMode, pointsScript.GetScore(currentGameMode));

        //Debug.Log("Clicked on " + this.GetComponent<Image>().name);
    }

    void LoseGame()
    {
        Debug.Log("LoseGame");
        GameObject.Find("GameManager").GetComponent<GameManager>().SaveHighscore();
        cdScript.GameOver();
    }

    IEnumerator RedBlink()
    {
        SetGameOver(true);
        this.GetComponent<Image>().color = Color.red;
        yield return new WaitForSeconds(1);
        this.GetComponent<Image>().color = Color.white;
        LoseGame();
    }

    public void SetGameOver(bool over)
    {
        Debug.Log("SetGameOver: " + over);
        gameOver = over;
    }


    // Update is called once per frame
    void Update()
    {
    }
}