using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostBehavior : MonoBehaviour
{
    GameObject paddle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.transform.position.x < 0)
        {
            paddle = GameObject.Find("LeftPaddle");
            increasePaddleSize();
            
        }
        else
        {
            paddle = GameObject.Find("RightPaddle");
            increasePaddleSize();
        }

        gameObject.SetActive(false);
    }

    private void increasePaddleSize()
    {
        if(paddle.GetComponent<PaddleMovement>().boostDuration == 0)
        {
            paddle.gameObject.transform.localScale += new Vector3 (0, 4, 0);
            paddle.GetComponent<PaddleMovement>().boostDuration = 3;
            paddle.GetComponent<PaddleMovement>().minY = -5.4f;
            paddle.GetComponent<PaddleMovement>().maxY = 5.4f;
        }
    }
}
