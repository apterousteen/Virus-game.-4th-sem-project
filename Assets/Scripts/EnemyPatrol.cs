﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : Enemy
{
    public float speed;
    public float currentSpeed;
    public int positionOfPatrol;
    public Transform point;
    bool movingRight;
    private bool faceRight = true;


    Transform player;
    public float stoppingDistance;

    bool chill = false;
    bool angry = false;
    bool goBack = false;

    protected override void Awake()
    {
        base.Awake();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        health = 4;
        currentSpeed = speed;
    }

    protected override void Update()
    {
        if (dazeTime <= 0)
            currentSpeed = speed;
        else{
            currentSpeed = 0;
            dazeTime -= Time.deltaTime;
        }

        if (Vector2.Distance(transform.position, point.position) < positionOfPatrol && (angry == false))
        {
            chill = true;
        }

        if (Vector2.Distance(transform.position, player.position) < stoppingDistance)
        {
            angry = true;
            chill = false;
            goBack = false;
        }

        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            goBack = true;
            angry = false;
        }

        if (chill == true)
        {
            Chill();
        }
        else if (angry == true)
        {
            GetAngry();
        }
        else if (goBack == true)
        {
            GoBack();
        }
    }

    void Chill()
    {
        if(transform.position.x > point.position.x + positionOfPatrol)
        {
            movingRight = false;
            Flip();
        }
        else if (transform.position.x < point.position.x - positionOfPatrol)
        {
            movingRight = true;
            Flip();
        }

        if (movingRight)
        {
            transform.position = new Vector2(transform.position.x + currentSpeed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - currentSpeed * Time.deltaTime, transform.position.y);
        }
    }

    void GetAngry()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, currentSpeed * Time.deltaTime);
        currentSpeed = 3;
    }

    void GoBack()
    {
        transform.position = Vector2.MoveTowards(transform.position, point.position, currentSpeed * Time.deltaTime);
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
    }

    void Flip()
    {
        faceRight = !faceRight;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        transform.localRotation = Quaternion.Euler(transform.localEulerAngles.x, transform.localEulerAngles.y, -transform.localEulerAngles.z);
    }
}
