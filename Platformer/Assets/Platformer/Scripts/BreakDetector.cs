using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakDetector : MonoBehaviour
{
    public GameObject gameManager;
    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Bounds bounds = GetComponent<Collider>().bounds;
       
        if(Physics.Raycast(transform.position, Vector3.up, out hit, bounds.extents.y + 0.95f))
        {
           
            if(hit.collider.gameObject.CompareTag("?"))
            {
                gameManager.GetComponent<GameManager>().qBox();
                Destroy(hit.collider.gameObject);
            }
            else if (hit.collider.gameObject.CompareTag("Brick"))
            {
                gameManager.GetComponent<GameManager>().brick();
                Destroy(hit.collider.gameObject);
            }
        }

    }
}

