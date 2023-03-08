using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreKeeper : MonoBehaviour
{
    public float enemyLineLength;
    
    private float score = 0;
    //private float enemyNumbers;
    private float highScore;
    
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highText;
    
    public delegate void respawn();
    public static event respawn respawnEntities;
    
    public delegate void clean();
    public static event clean cleanEntities;
    // Start is called before the first frame update
    void Start()
    {
        highScore = PlayerPrefs.GetFloat("highScore");
        if (highScore < 1)
        {
            highText.text = $"Hi-Score:\n0000";
        }
        else if (highScore < 1000)
        {
            highText.text = $"Hi-Score:\n0{highScore}";
        }
        else
        {
            highText.text = $"Hi-Score:\n{highScore}";
        }
        
        //enemyNumbers = enemyLineLength * 4;
        Enemy.upOnDeath += enemyHasBeenDestroyed;
        Player.reset += restartGame;
    }

    private void enemyHasBeenDestroyed(GameObject enemy)
    {
        string tag = enemy.tag;
        
        if (tag == "Green")
        {
            score += 100;
        }
        else if (tag == "Blue")
        {
            score += 200;
        } 
        else if (tag == "Red")
        {
            score += 300;
        }
        else if (tag == "Purple")
        {
            score += 400;
        }

        if (score > 1000)
        { 
            scoreText.text = $"Score:\n{score}";
        }
        else
        {
            scoreText.text = $"Score:\n0{score}";
        }

        // enemyNumbers -= 1;
        // if (enemyNumbers == 0)
        // {
        //     successRestart();
        // }
        //throw new System.NotImplementedException();
    }
    // Update is called once per frame
    void Update()
    {
    if (GameObject.FindWithTag("Red") == null 
        && GameObject.FindWithTag("Blue") == null
        && GameObject.FindWithTag("Green") == null
        && GameObject.FindWithTag("Purple") == null)
    {
        successRestart();
    }
    }

    void successRestart()
    {
        cleanEntities.Invoke();
        respawnEntities.Invoke();
    }
    
    void restartGame()
    {
        scoreText.text = $"Score:\n0000";
        
        if (highText.text == "Hi-Score:\n0000" || score > highScore)
        {
            PlayerPrefs.DeleteKey("highScore");
            setHighScore();
        }
        score = 0;
        cleanEntities.Invoke();
        respawnEntities.Invoke();
        
    }

    void setHighScore()
    {
        PlayerPrefs.SetFloat("highScore", score);
        PlayerPrefs.Save();
        if (score < 1000)
        {
            highText.text = $"Hi-Score:\n0{PlayerPrefs.GetFloat("highScore")}";
        }
        else
        {
            highText.text = $"Hi-Score:\n{PlayerPrefs.GetFloat("highScore")}";
        }
        
    }
}
