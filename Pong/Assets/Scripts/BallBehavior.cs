using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    private float leftPlayerScore = 0;
    private float rightPlayerScore = 0;
    public float ballSpeed = 500f;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log($"Left Player: {leftPlayerScore}   Right Player: {rightPlayerScore}");
        Vector3 force = Vector3.left * 500f;
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(force, ForceMode.Force);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "RightLossDetector")
        {
            leftPlayerScore += 1;
            if(leftPlayerScore == 11)
            {
                leftPlayerScore = 0;
                rightPlayerScore = 0;
                Debug.Log("Game Over, Left Paddle Wins!");
                resetBall("right");
            } else
            {
                Debug.Log($"Left Player: {leftPlayerScore}   Right Player: {rightPlayerScore}");
                resetBall("right");
            }
        } else if(collision.gameObject.name == "LeftLossDetector")
        {
            rightPlayerScore += 1;
            if (rightPlayerScore == 11)
            {
                leftPlayerScore = 0;
                rightPlayerScore = 0;
                Debug.Log("Game Over, Right Paddle Wins!");
                resetBall("left");
            }
            else
            {
                Debug.Log($"Left Player: {leftPlayerScore}   Right Player: {rightPlayerScore}");
                resetBall("left");
            }
        }
    }

    void resetBall(string leftOrRight)
    {
        var lPaddle = GameObject.Find("LeftPaddle");
        var rPaddle = GameObject.Find("RightPaddle");

        lPaddle.transform.position = new Vector3(-14, 0, 0);
        rPaddle.transform.position = new Vector3(14, 0, 0);

        var leftSpeed = lPaddle.GetComponent<PaddleMovement>();
        var rightSpeed = rPaddle.GetComponent<PaddleMovement>();

        ballSpeed = 500f;

        Transform t = GetComponent<Transform>();
        t.position = Vector3.zero;

        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;

        if (leftOrRight == "left")
        { 
            Vector3 force = Vector3.left * 500f;
            rb.AddForce(force, ForceMode.Force);
        }
        else
        {
            Vector3 force = Vector3.right * 500f;
            rb.AddForce(force, ForceMode.Force);
        }
    }
}
