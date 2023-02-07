using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    public float unitsPerSecond = 10;
    private float verticalValue1;
    private float verticalValue2;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void FixedUpdate()
    {
        Vector3 leftVector = new Vector3(0f, verticalValue1, 0f);
        if (gameObject.name == "LeftPaddle")
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.velocity = Vector3.up * verticalValue1 * unitsPerSecond;

            
        }
        else
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.velocity = Vector3.up * verticalValue2 * unitsPerSecond;
            

        }
       

    }

    // Update is called once per frame
    void Update()
    {
        verticalValue1 = Input.GetAxis("Vertical");
        verticalValue2 = Input.GetAxis("VerticalRight");
    }

    private void OnCollisionEnter(Collision collision)
    {

        BoxCollider bc = GetComponent<BoxCollider>();
        float ballSpeed = GameObject.Find("Ball").GetComponent<BallBehavior>().ballSpeed;
        Bounds bounds = bc.bounds;

        float minY = bounds.min.y;

        float ballPosition = collision.transform.position.y;
        float location = ballPosition - minY;

        float portion = location / 4;

        float portionNormalized = 2 * ((portion - 0) / (1 - 0)) - 1;
        float bounceAngle = portionNormalized * 60;
        
        
        if (gameObject.name == "LeftPaddle")
        {
            Quaternion rotation = Quaternion.Euler(0f, 0f, bounceAngle);

            Vector3 bounceDirection = rotation * Vector3.right;
            Rigidbody rb = collision.rigidbody;
            rb.AddForce(bounceDirection * ballSpeed, ForceMode.Force);
        }
        else
        {
            bounceAngle *= -1;
            Quaternion rotation = Quaternion.Euler(0f, 0f, bounceAngle);

            Vector3 bounceDirection = rotation * Vector3.left;
            Rigidbody rb = collision.rigidbody;
            rb.AddForce(bounceDirection * ballSpeed,ForceMode.Force);
           
        }

        GameObject.Find("Ball").GetComponent<BallBehavior>().ballSpeed += 100;
    }
}