using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float Damage = 1f;
    public float Speed = 100f;
    public float PushForce = 1f;
    //public float LifeTime = 1f;
    public LayerMask TargetLayerMask;

    private Rigidbody2D _rigidbody;
    private float _timer = 0f;
    private BulletCollision _damageOnTouch;
    public Cooldown LifeTime;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        if (_rigidbody == null)
            return;
        _rigidbody.AddRelativeForce(new Vector2(0f, Speed));

        _damageOnTouch = GetComponent<BulletCollision>();
        if (_damageOnTouch != null)
            _damageOnTouch.OnHit += Die;
        LifeTime.StartCooldown();
    }
    private void Update()
    {
        if (LifeTime.CurrentProgress != Cooldown.Progress.Finished)
            return;

        Die();
    }
    private void Die()
    {
        if (_damageOnTouch != null)
            _damageOnTouch.OnHit -= Die;

        LifeTime.StopCooldown();
        Destroy(gameObject);
    }
}
