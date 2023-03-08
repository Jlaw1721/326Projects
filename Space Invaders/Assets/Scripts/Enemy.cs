using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
  public delegate void EnemyDestroyed();
  public static event EnemyDestroyed OnEnemyHit;
  
  public delegate void scoreIncrease(GameObject enemy);
  public static event scoreIncrease upOnDeath;
  
  public GameObject bulletPrefab;
  
  private string direction;
  private GameObject specificObject;
  
  public float enemySpeed = 1;
  public float enemyAmount;
    // Start is called before the first frame update
    private void Start()
    {
      specificObject = this.gameObject;
      direction = "Left";
      BoundManager.EnemyContact += changeEnemyDirection;
      OnEnemyHit += increaseSpeed;
      ScoreKeeper.cleanEntities += Kill;
    }

    private void Update()
    {
      if (direction == "Left")
      {
        transform.position += enemySpeed * Vector3.left * Time.deltaTime;
      }
      else if (direction == "Right")
      {
        transform.position += enemySpeed * Vector3.right * Time.deltaTime;
      }
    }

    private void FixedUpdate()
    {
      float triggerPullDecider = Mathf.Floor(Random.Range(1f, 500f));

      if (triggerPullDecider == 1f)
      {
        GameObject shot = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        
        if (shot != null)
        {
          Destroy(shot, 3f);
        }
      }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
      
        OnEnemyHit.Invoke();
        upOnDeath.Invoke(this.gameObject);
        Destroy(collision.gameObject);
        Destroy(this.gameObject);
       
      
    }

    void changeEnemyDirection()
    {
      
      if (specificObject != null)
      {
        transform.position = new Vector3(transform.position.x, (transform.position.y - 1f), transform.position.z);
      
        if (direction == "Left")
        {
          direction = "Right";
        }
        else
        {
          direction = "Left";
        }
      }
      
    }

    void increaseSpeed()
    {
      float increaseValue = 10 - enemyAmount;
      if (enemyAmount == 10)
      {
        increaseValue++;
      }
      enemySpeed += (increaseValue * 0.10f);
    }
    
    void Kill()
        {
          if (specificObject != null)
          {
            Destroy(this.gameObject);
          }
        }
}
