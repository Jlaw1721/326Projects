using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    private float leftPlayerScore = 0;
    private float rightPlayerScore = 0;
    private float leftPlayerWins = 0;
    private float rightPlayerWins = 0;
    private int powerUpLimit = 4;

    public GameObject boost1, boost2, change1, change2;
    public TextMeshProUGUI rightScoreText, leftScoreText, rightWin, leftWin;
    public float ballSpeed;

    // Start is called before the first frame update
    void Start()
    {
        //rightScore.text = $"Score: {rightPlayerScore}";
        //leftScore.text = $"Score: {leftPlayerScore}";
        //Vector3 force = Vector3.left * 500f;
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.left * ballSpeed;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        powerUpLimit--;

        if (powerUpLimit == 0)
        {
            boost1.SetActive(true);
            boost2.SetActive(true);
            change1.SetActive(true);
            change2.SetActive(true);

            powerUpLimit = 4;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "RightLossDetector")
        {
            leftPlayerScore += 1;

            if (leftPlayerScore > 7)
            {
                leftScoreText.color = Color.red;
            }

            if (leftPlayerScore == 11)
            {
                leftPlayerScore = 0;
                rightPlayerScore = 0;

                leftPlayerWins++;
                leftWin.text = $"Wins: {leftPlayerWins}";
                
                leftScoreText.color = Color.white;
                resetBall("right");
            } else
            {
                resetBall("right");
            }
        } else if(collision.gameObject.name == "LeftLossDetector")
        {
            rightPlayerScore += 1;

            if (rightPlayerScore > 7)
            {
                rightScoreText.color = Color.red;
            }

            if (rightPlayerScore == 11)
            {
                leftPlayerScore = 0;
                rightPlayerScore = 0;

                rightPlayerWins++;
                rightWin.text = $"Wins: {rightPlayerWins}";
                
                rightScoreText.color = Color.white;
                resetBall("left");
            }
            else
            {
                
                resetBall("left");
            }
        }
    }

    void resetBall(string leftOrRight)
    {
        leftScoreText.text = $"Score: {leftPlayerScore}";
        rightScoreText.text = $"Score: {rightPlayerScore}";

        var lPaddle = GameObject.Find("LeftPaddle");
        var rPaddle = GameObject.Find("RightPaddle");

        lPaddle.transform.position = new Vector3(-14, 0, 0);
        rPaddle.transform.position = new Vector3(14, 0, 0);

        ballSpeed = 5f;

        Transform t = GetComponent<Transform>();
        t.position = Vector3.zero;

        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;

        if (leftOrRight == "left")
        {
            rb.velocity = Vector3.left * ballSpeed;
        }
        else
        {
            rb.velocity = Vector3.right * ballSpeed;
    
        }
    }
}
