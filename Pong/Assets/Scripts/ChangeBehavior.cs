using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        float ballSpeed = GameObject.Find("Ball").GetComponent<BallBehavior>().ballSpeed;
        Quaternion randomAngle = Quaternion.Euler(0f, 0f, Random.Range(-360f, 360f));
        Vector3 bounceDirection = randomAngle * Vector3.left;

        Rigidbody rb = other.GetComponent<Rigidbody>();

        rb.AddForce(bounceDirection * ballSpeed, ForceMode.VelocityChange);

        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
