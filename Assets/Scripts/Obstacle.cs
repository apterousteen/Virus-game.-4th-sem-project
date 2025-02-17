﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : Enemy
{
    protected override void Awake()
    {
        base.Awake();
        health = 2;
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
        if (collision.gameObject.tag == "Player")
        {
            GetDamage(1);
        }
    }

    /*
    [SerializeField] private int lives = 3;

    public virtual void Die()
    {
        Destroy(this.gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Health.Instance.gameObject)
        {
            Health.Instance.GetDamage();
            lives--;
            Debug.Log("Obstacle's HP: " + lives);
        }
        if (lives < 1)
        {
            Die();
        }
    }
    */
}
