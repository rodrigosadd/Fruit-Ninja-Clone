using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public CatchUncutFruits instanceCatchUncutFruits;
    public UIController instanceUI;
    public PoolSystem instancePoolSystem;
    public Cut instanceCut;
    public int points;
    public float gameMinutes;
    public float gameplayTime;
    public bool isEndGame;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        ConvertToMinutes();
    }

    void Update()
    {
        GameplayTime();
        CheckEndGame();
    }

    void ConvertToMinutes()
    {
        gameplayTime = gameMinutes * 60;
    }

    void GameplayTime()
    {
        if(!isEndGame)
        {
            if(gameplayTime < 10f)
            {
                instanceUI.timerText.color = Color.red;
            }

            gameplayTime -= Time.deltaTime * 1;
        }
    }

    void CheckEndGame()
    {
        if(gameplayTime <= 0)
        {
            isEndGame = true;
            instanceCut.cutCollider.enabled = false;
        }
    }

    public static CatchUncutFruits GetUncutFruits()
    {
        return instance.instanceCatchUncutFruits;
    }

    public static UIController GetUI()
    {
        return instance.instanceUI;
    }

    public static Cut GetCut()
    {
        return instance.instanceCut;
    }

    public static PoolSystem GetPool()
    {
        return instance.instancePoolSystem;
    }

    public void ResetValues()
    {
        points = 0;
        gameplayTime = 0;
        gameplayTime = gameMinutes * 60;
        isEndGame = false;
        instanceCatchUncutFruits.uncutFruits = 0;
    }
}
