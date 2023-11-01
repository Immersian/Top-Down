using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float Speed = 1f;
    Rigidbody2D _rigidbody;
    Collider2D _collider2D;
    private float t = 0.0f;
    public float Horizontal;
    public float Vertical;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _collider2D = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");
        Vertical = Input.GetAxisRaw("Vertical");

        
    }
    public void FixedUpdate()
    {
        _rigidbody.velocity = new Vector2(Horizontal * Speed, Vertical * Speed);
    }
}
