using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameEnded;

    public GameObject gameOverUI;
    // Update is called once per frame

    private void Start()
    {
        gameEnded = false;
    }

    void Update()
    {
        if (gameEnded)
        {
            return;
        }
        
        if (PlayerStats.lives <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        gameEnded = true;
        
        gameOverUI.SetActive(true);
    }
}
