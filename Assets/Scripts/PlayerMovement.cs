using System.Collections;
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

    private bool jumpedOnce = false;
    private bool isJumping = false;

    public float dashForce;
    public float dashCooldownValue = 1.0f;
    private float dashCooldownTime = 0;
    private float direction;

    void Start()
    {
        virus_body = GetComponent<Rigidbody2D>();
        extraJumps = extraJumpsValue;
    }

    private void FixedUpdate()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        Vector2 movement = new Vector2(deltaX, virus_body.velocity.y);
        if (movement.x >= 0)
            direction = 1;
        else direction = -1;
        virus_body.velocity = movement;
    }

    void Update()
    {
        bool grounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if (Input.GetKeyDown(KeyCode.Space) && dashCooldownTime <= 0)
        {
            virus_body.AddForce(new Vector2(direction * dashForce, 0));
            dashCooldownTime = dashCooldownValue;
        }

        if (dashCooldownTime > 0)
            dashCooldownTime -= Time.deltaTime;
        

        if (grounded)
            extraJumps = extraJumpsValue;
        else if (extraJumps == extraJumpsValue)
            extraJumps = 0;
        if((extraJumps > 0) && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)))
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
}
