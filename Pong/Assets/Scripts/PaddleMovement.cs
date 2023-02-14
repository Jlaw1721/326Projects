using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    public float unitsPerSecond = 10;
    public float minY = -7.4f;
    public float maxY = 7.4f;
    public AudioClip lowSpeedHit;
    public AudioClip highSpeedHit;

    [HideInInspector] public int boostDuration = 0;
    

    private float verticalValue1;
    private float verticalValue2;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void FixedUpdate()
    {
       
        if (gameObject.name == "LeftPaddle")
        {
            //Rigidbody rb = GetComponent<Rigidbody>();
            //rb.velocity = Vector3.up * verticalValue1 * unitsPerSecond;
            Vector3 currentLoc = transform.position;

            Vector3 paddleMove = new Vector3(0, Mathf.Clamp(verticalValue1, minY, maxY), 0);
            transform.Translate(paddleMove * unitsPerSecond * Time.deltaTime);

            if (transform.position.y > maxY || transform.position.y < minY)
            {
                transform.position = currentLoc;
            }  
        }
        else
        {
            //Rigidbody rb = GetComponent<Rigidbody>();
            //rb.velocity = Vector3.up * verticalValue2 * unitsPerSecond;
            Vector3 currentLoc = transform.position;

            Vector3 paddleMove = new Vector3(0, verticalValue2, 0);
            transform.Translate(paddleMove * unitsPerSecond * Time.deltaTime);

            if (transform.position.y > maxY || transform.position.y < minY)
            {
                transform.position = currentLoc;
            }
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
        if(boostDuration > 0)
        {
            boostDuration--;
            if(boostDuration == 0)
            {
                transform.localScale += new Vector3(0, -4, 0);
                maxY = 7.4f;
                minY = -7.4f;
            }
        }

        BoxCollider bc = GetComponent<BoxCollider>();
        float ballSpeed = GameObject.Find("Ball").GetComponent<BallBehavior>().ballSpeed;
        Bounds bounds = bc.bounds;

        float minSizeY = bounds.min.y;

        float ballPosition = collision.transform.position.y;
        float location = ballPosition - minSizeY;

        float portion = location / bounds.size.y;

        float portionNormalized = 2 * ((portion - 0) / (1 - 0)) - 1;
        float bounceAngle = portionNormalized * 60;

        ballSpeed += 2;

        
        if(collision.gameObject.name == "Ball")
        {
            AudioSource audioSource = GetComponent<AudioSource>();
            if (ballSpeed >= 25)
            {
                audioSource.clip = highSpeedHit;
                audioSource.volume = .5f;
                audioSource.Play();
            }
            else
            {
                audioSource.clip = lowSpeedHit;
                audioSource.volume = 1;
                audioSource.Play();
            }
        }
        

        
        if (gameObject.name == "LeftPaddle")
        {
            Quaternion rotation = Quaternion.Euler(0f, 0f, bounceAngle);

            Vector3 bounceDirection = rotation * Vector3.right;
            Rigidbody rb = collision.rigidbody;
            rb.AddForce(bounceDirection * ballSpeed, ForceMode.VelocityChange);
        }
        else if(gameObject.name == "RightPaddle")
        {
            bounceAngle *= -1;
            Quaternion rotation = Quaternion.Euler(0f, 0f, bounceAngle);

            Vector3 bounceDirection = rotation * Vector3.left;
            Rigidbody rb = collision.rigidbody;
            rb.AddForce(bounceDirection * ballSpeed, ForceMode.VelocityChange);
        }

        GameObject.Find("Ball").GetComponent<BallBehavior>().ballSpeed += 2;
    }
}