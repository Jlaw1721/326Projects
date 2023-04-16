using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int money;
    public static int lives;
    
    public int startMoney = 400;
    public int startLives = 20;

    public static int Rounds;
    
    private void Start()
    {
        lives = startLives;
        money = startMoney;
        Rounds = 0;
    }
    
    
}
