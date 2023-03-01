using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float runForce = 50f;
    public float jumpImpulseForce = 20f;
    public float jumpSustainForce = 7.5f;
    public float maxHorizontalSpeed = 6f;

    public bool groundContact = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Bounds bounds = GetComponent<Collider>().bounds;
        groundContact = Physics.Raycast(transform.position, Vector3.down, bounds.extents.y + 0.1f);

        var axis = Input.GetAxis("Horizontal");
        if(axis != 0){
            transform.forward = new Vector3(axis, 0, 0);
        }
        Rigidbody rbody = GetComponent<Rigidbody>();
        rbody.AddForce(Vector3.right * axis * runForce, ForceMode.Force);

        if(groundContact && Input.GetKeyDown(KeyCode.Space)){
            rbody.AddForce(Vector3.up * jumpImpulseForce, ForceMode.Impulse);
        } else if(Input.GetKey(KeyCode.Space)){
            rbody.AddForce(Vector3.up * jumpSustainForce, ForceMode.Force);
        }

        if(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)){
            rbody.velocity = new Vector3(8 * axis, rbody.velocity.y, rbody.velocity.z);
        } else {
            float xVelo = Mathf.Clamp(rbody.velocity.x, -maxHorizontalSpeed, maxHorizontalSpeed);

            if(Mathf.Abs(axis) < 0.1f){
                xVelo *= 0.9f;
            }

            rbody.velocity = new Vector3(xVelo, rbody.velocity.y, rbody.velocity.z);
        }
        float speed = rbody.velocity.magnitude;
        Animator animator = GetComponent<Animator>();
        animator.SetFloat("Speed", speed);
        animator.SetBool("Jumping", !groundContact);
    }
}
