using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 300.0f;
    public float jumpForce = 15.0f;

    private BoxCollider2D virus_box;
    private Rigidbody2D virus_body;

    private bool jumpedOnce = false;

    void Start()
    {
        virus_body = GetComponent<Rigidbody2D>();
        virus_box = GetComponent<BoxCollider2D>();
    }

    
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        Vector2 movement = new Vector2(deltaX, virus_body.velocity.y);
        virus_body.velocity = movement;
        Vector3 max = virus_box.bounds.max;
        Vector3 min = virus_box.bounds.min;
        Vector2 corner1 = new Vector2(max.x, min.y - 0.1f);
        Vector2 corner2 = new Vector2(max.x, min.y - 0.2f);
        Collider2D hit = Physics2D.OverlapArea(corner1, corner2);
        bool grounded = false;
        if (hit != null)
            grounded = true;
        if((grounded || jumpedOnce) && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)))
        {
            virus_body.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            if (jumpedOnce)
                jumpedOnce = false;
            else jumpedOnce = true;
        }
    }
}
