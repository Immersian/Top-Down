using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 0.5f;
    public Rigidbody2D rb;
    public Collider2D _collider2D;
    private Vector2 input;
    public GameObject graphics;

    Animator anim;
    private Vector2 lastMoveDirection;
    private bool facingLeft = false;
    SpriteRenderer _spritePlayer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _collider2D = GetComponent<Collider2D>();
        _spritePlayer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
        Animate();
        if (input.x < 0 && !facingLeft || input.x  > 0 && facingLeft) 
        {
            Flip();
        }

    }
    public void FixedUpdate()
    {
        rb.velocity = input * speed;
    }
    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if ((moveX != 0 || moveY != 0) && (moveX == 0 || moveY == 0))
        {
            lastMoveDirection = new Vector2(moveX, moveY);
        }

        input.x = moveX;
        input.y = moveY;

        input.Normalize();
    }
    void Animate()
    {
        anim.SetFloat("MoveX", input.x);
        anim.SetFloat("MoveY", input.y);
        anim.SetFloat("MoveMagnitude", input.magnitude);
        anim.SetFloat("LastMoveX", lastMoveDirection.x);
        anim.SetFloat("LastMoveY", lastMoveDirection.y);
    }
    void Flip()
    {
        Vector3 scale = graphics.transform.localScale;
        scale.x *= -1;
        graphics.transform.localScale = scale;
        facingLeft = !facingLeft;
        
    }
}
