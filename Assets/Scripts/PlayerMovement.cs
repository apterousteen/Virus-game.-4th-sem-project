﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 300.0f;
    public float jumpForce = 1.0f;
    private float jumpTimeCounter;
    public float jumpTime = 0.25f;
    public int extraJumpsValue = 2;
    private int extraJumps;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    private Rigidbody2D virus_body;
    private BoxCollider2D virus_box;

    private bool jumpedOnce = false;
    private bool isJumping = false;

    public float dashDistance;
    public float dashCooldownValue = 1.0f;
    private float dashCooldownTime = 0;
<<<<<<< Updated upstream
    private float direction;

    void Start()
    {
=======
    private bool faceRight = true;

    //for interaction with enemies
    public static PlayerMovement Instance { get; set; }

    void Start()
    {
        Instance = this;

>>>>>>> Stashed changes
        virus_body = GetComponent<Rigidbody2D>();
        virus_box = GetComponent<BoxCollider2D>();
        extraJumps = extraJumpsValue;
    }

    private void FixedUpdate()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        Vector2 movement = new Vector2(deltaX, virus_body.velocity.y);
        virus_body.velocity = movement;
<<<<<<< Updated upstream
=======


        if (deltaX > 0 && !faceRight)
            Flip();
        else if (deltaX < 0 && faceRight)
            Flip();

    }

    void Flip()
    {
        faceRight = !faceRight;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        transform.localRotation = Quaternion.Euler(transform.localEulerAngles.x, transform.localEulerAngles.y, -transform.localEulerAngles.z);
>>>>>>> Stashed changes
    }

    void Update()
    {
        bool grounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        HandleDash();

        if (grounded)
            extraJumps = extraJumpsValue;
        else if (extraJumps == extraJumpsValue)
            extraJumps = 0;
        if ((extraJumps > 0) && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)))
        {
            virus_body.velocity = Vector2.up * jumpForce;
            isJumping = true;
            jumpTimeCounter = jumpTime;
            extraJumps--;
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            if (jumpTimeCounter > 0)
            {
                virus_body.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else isJumping = false;
        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
            isJumping = false;
    }
<<<<<<< Updated upstream
=======

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Platform")
            transform.parent = other.gameObject.transform;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Platform")
            transform.parent = null;
    }

    private bool CanDash(Vector2 dir, float distance)
    {
        return Physics2D.Raycast(transform.position, dir, distance).collider == null;
    }

    private bool TryDash(bool facingRight, float distance)
    {
        Vector3 dashDir;
        virus_box.enabled = false;
        var distanceToDash = distance;
        if (facingRight)
            dashDir = new Vector3(1, 0, 0);
        else dashDir = new Vector3(-1, 0, 0);
        bool canDash = CanDash(dashDir, distance);
        if(!canDash)
        {
            var hit = Physics2D.Raycast(transform.position, dashDir, distance);
            distanceToDash = hit.distance - virus_box.size.x / 2;
            canDash = CanDash(dashDir, distanceToDash);
        }
        virus_box.enabled = true;
        if (canDash)
        {
            transform.position += dashDir * distanceToDash;
            return true;
        }
        else return false;
    }
    private void HandleDash()
    {
        if (Input.GetKeyDown(KeyCode.Space) && dashCooldownTime <= 0)
            if (TryDash(faceRight, dashDistance))
                dashCooldownTime = dashCooldownValue;

        if (dashCooldownTime > 0)
            dashCooldownTime -= Time.deltaTime;
    }

    // new
    // HP level
    //[SerializeField] private int lives = 5;


    //public virtual void Die()
    //{
    //    Destroy(this.gameObject);
    //    EndGame();
    //}

    //public void GetDamage()
    //{
    //    lives -= 1;
    //    Debug.Log(lives);
    //    Health.UpdateHealth();
    //}

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject == Instance.gameObject)
    //    {
    //        Instance.GetDamage();
    //        lives--;
    //        Debug.Log("Player's HP: " + lives);
    //    }
    //    if (lives < 1)
    //    {
    //        Die();
    //    }
    //}

    //void EndGame()
    //{ 
    //    if (lives == 0)
    //    {
    //        SceneManager.LoadScene(1);
    //    }
    //}
>>>>>>> Stashed changes
}
