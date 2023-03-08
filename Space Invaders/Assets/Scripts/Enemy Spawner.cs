using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject redGuy;
    public GameObject blueGuy;
    public GameObject purpleGuy;
    public GameObject greenGuy;
    public GameObject barricade;
    public GameObject player;
    
    public int enemyAmount;
    
    // Start is called before the first frame update
    private void Start()
    {
        spawn();
        ScoreKeeper.respawnEntities += spawn;
    }

    public void spawn()
    {
        float xPosition = 0 - (enemyAmount - 1);
        for (int i = 0; i < enemyAmount; i++)
        {
            Instantiate(purpleGuy, new Vector3(xPosition, 7f, 0f), Quaternion.identity);
            xPosition += 2;
        }
        
        xPosition = 0 - (enemyAmount - 1);
        for (int i = 0; i < enemyAmount; i++)
        {
            Instantiate(redGuy, new Vector3(xPosition, 5f, 0f), Quaternion.identity);
            xPosition += 2;
        }
        
        xPosition = 0 - (enemyAmount - 1);
        for (int i = 0; i < enemyAmount; i++)
        {
            Instantiate(blueGuy, new Vector3(xPosition, 3f, 0f), Quaternion.identity);
            xPosition += 2;
        }
        
        xPosition = 0 - (enemyAmount - 1);
        for (int i = 0; i < enemyAmount; i++)
        {
            Instantiate(greenGuy, new Vector3(xPosition, 1f, 0f), Quaternion.identity);
            xPosition += 2;
        }
        
        Instantiate(barricade, new Vector3(0f, -5f, 0f), Quaternion.identity);
        Instantiate(barricade, new Vector3(-8f, -5f, 0f), Quaternion.identity);
        Instantiate(barricade, new Vector3(8f, -5f, 0f), Quaternion.identity);
        Instantiate(player, new Vector3(0f, -7f, 0f), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
