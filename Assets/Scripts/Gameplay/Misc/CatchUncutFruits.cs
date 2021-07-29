using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchUncutFruits : MonoBehaviour
{
    public int uncutFruits;
    private Collider uncutCollider;

    void Start()
    {
        uncutCollider = GetComponent<Collider>();
    }

    void Update()
    {
        CheckEndGame();
    }

    void CheckEndGame()
    {
        if(uncutFruits >= 10)
        {
            GameManager.instance.isEndGame = true;
            uncutCollider.enabled = false;
        }
    }
}
