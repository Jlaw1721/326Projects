using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarricadeBehavior : MonoBehaviour
{
    public float enemyLineAmount;
    
    private float health;
    private GameObject specificObject;
    // Start is called before the first frame update
    void Start()
    {
        specificObject = this.gameObject;
        health = enemyLineAmount * 2;
        ScoreKeeper.cleanEntities += Kill;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(col.gameObject);
        health--;
        if (health == 0)
        {
            Destroy(this.gameObject);
        }
    }
    
    void Kill()
    {
        if (specificObject != null)
        {
            Destroy(this.gameObject);
        }
    }
}
