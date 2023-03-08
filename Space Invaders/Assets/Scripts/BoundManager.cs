using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BoundManager : MonoBehaviour
{
    public delegate void EnemyReachedBound();
    public static event EnemyReachedBound EnemyContact;

    private GameObject specificObject;

    private bool leftActive;
    private bool rightActive;
    // Start is called before the first frame update
    void Start()
    {
        setActives();
        ScoreKeeper.cleanEntities += setActives;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void enemyHitBounds(GameObject bound)
    {
        if (bound.name == "LeftBound" && leftActive == true)
        {
            EnemyContact.Invoke();
            leftActive = false;
            rightActive = true;
        }
        else if(bound.name == "RightBound" && rightActive == true)
        {
            EnemyContact.Invoke();
            leftActive = true;
            rightActive = false;
        }
    }

    void setActives()
    {
        leftActive = true;
        rightActive = false;
    }
}