using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;
    [HideInInspector]
    public float moveSpeed;
    
    public float health = 100f;
    public int worth = 50;

    public GameObject deathEffect;

    private void Start()
    {
        moveSpeed = startSpeed;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Die();
        }
    }

    public void Slow(float pct)
    {
        moveSpeed = startSpeed * (1f - pct);
    }
    void Die()
    {
        PlayerStats.money += worth;
        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        
        Destroy(effect, 5f);
        Destroy(gameObject);
    }
}
