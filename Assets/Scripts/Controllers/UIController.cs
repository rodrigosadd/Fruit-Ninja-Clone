using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    public GameObject endGamePanel;
    public TextMeshProUGUI scoreEndGameText;
    public TextMeshProUGUI pointsText;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI uncutText;

    void Update()
    {
        GetTime();
        GetPoints();
        GetUncut();
        GetEndGame();
    }

    void GetTime()
    {
        timerText.text = GameManager.instance.gameplayTime.ToString("00.0");
    }

    void GetPoints()
    {
        pointsText.text = GameManager.instance.points.ToString("00");
    }

    void GetUncut()
    {
        uncutText.text = GameManager.GetUncutFruits().uncutFruits.ToString("00");
    }

    void GetEndGame()
    {
        if(GameManager.instance.isEndGame)
        {
            endGamePanel.SetActive(true);
            scoreEndGameText.text = GameManager.instance.points.ToString("00");
        }
    }

    public void PlayAgain()
    {
        ResetValues();
        GameManager.instance.ResetValues();
    }


    void ResetValues()
    {
        scoreEndGameText.text = 0f.ToString("00");
        timerText.text = 0.ToString("00");
        pointsText.text = 0.ToString("00");
        uncutText.text = 0.ToString("00");
        endGamePanel.SetActive(false);
    }
}
