using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
  public delegate void playerDied();
  public static event playerDied reset;
  
  public float playerSpeed = 1f;
  public GameObject bulletPrefab;
  private GameObject specificObject;
  
  public Transform shootingOffset;

  private void Start()
  {
    specificObject = this.gameObject;
    ScoreKeeper.cleanEntities += Kill;
  }

  // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyDown(KeyCode.Space))
      {
        GameObject shot = Instantiate(bulletPrefab, transform.GetChild(0).position, Quaternion.identity);
        
        
        if (shot != null)
        {
          Destroy(shot, 3f);
        }

      }
      float movement = Input.GetAxis("Horizontal") * playerSpeed;
      
      transform.position += movement * Vector3.right * Time.deltaTime;

      transform.position = new Vector3(Mathf.Clamp(transform.position.x, -15f, 15f), 
        transform.position.y, transform.position.z);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
      Destroy(col.gameObject);
      Destroy(this.gameObject);
      reset.Invoke();
    }
    
    void Kill()
    {
      if (specificObject != null)
      {
        Destroy(this.gameObject);
      }
    }
}
