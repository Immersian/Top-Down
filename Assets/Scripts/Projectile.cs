using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float Damage = 1f;
    public float Speed = 100f;
    public float PushForce = 1f;
    public float LifeTime = 1f;
    public LayerMask TargetLayerMask;

    private Rigidbody2D _rigidbody;
    private float _timer = 0f;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        if (_rigidbody == null)
            return;
        _rigidbody.AddRelativeForce(new Vector2(0f, Speed));
    }
    private void Update()
    {
        if (_timer < LifeTime)
        {
            _timer += Time.deltaTime;
            return;
        }
        Die();
    }
    private void Die()
    {
        Destroy(gameObject);
    }
}