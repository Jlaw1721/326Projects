using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyShotBehavior : MonoBehaviour
{
    private Rigidbody2D myRigidbody2D;
    private GameObject specificObject;
    public float speed = 5;
    // Start is called before the first frame update
    void Start()
    {

        specificObject = this.gameObject;
        myRigidbody2D = GetComponent<Rigidbody2D>();
        ScoreKeeper.cleanEntities += Kill;
        Fire();
    }

    // Update is called once per frame
    private void Fire()
    {
        myRigidbody2D.velocity = Vector2.down * speed;
    }
    
    void Kill()
    {
        if (specificObject != null)
        {
            Destroy(this.gameObject);
        }
    }
    
}
