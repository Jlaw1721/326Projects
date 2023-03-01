using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int coins = 0;
    private int score = 0;
    public GameObject levelRestarter;
    public GameObject player;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI victoryText;
    public TextMeshProUGUI failText;
    void Start()
    {
        victoryText.enabled = false;
        failText.enabled = false;
    }

    public void hitWater(){
        player.transform.position = new Vector3(10.78f, 1.6f, 0f);

        timerText.GetComponent<Timer>().timerRunning = true;
        timerText.GetComponent<Timer>().time = 100f;

        coinText.text = "C x 00";
        scoreText.text = "Score: 0000";

        victoryText.enabled = false;
        failText.enabled = false;
        
        coins = 0;
        score = 0;
        levelRestarter.GetComponent<LevelParser>().onDeath();
    }

    public void hitCoin(){
        coins++;
        if(coins < 10){
            coinText.text = $"C x 0{coins}";
        } else {
            coinText.text = $"C x {coins}";
        }

        score += 100;
        if(score < 1000){
            scoreText.text = $"Score: 0{score}";
        } else {
            scoreText.text = $"Score: {score}";
        }
    }

    public void brick(){
        score += 100;
        if(score < 1000){
            scoreText.text = $"Score: 0{score}";
        } else {
            scoreText.text = $"Score: {score}";
        }
    }

    public void qBox(){
        for(int i = 0; i < 3; i++){
            hitCoin();
        }
    }

    public void hitGoal(){
        if(timerText.GetComponent<Timer>().timerRunning){
            victoryText.enabled = true;
        }
    }
}
