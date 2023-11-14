using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    public delegate void OnHitSomething();
    public OnHitSomething OnHit;

    public float Damage = 1f;
    public LayerMask TargetLayerMask;
    public GameObject Bullet;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Destroy(Bullet);
        }
    }
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (!((TargetLayerMask.value & (1 << col.gameObject.layer)) > 0))
            return;

        Health targetHealth = col.gameObject.GetComponent<Health>();

        if (targetHealth == null)
            return;

        TryDamage(targetHealth);
    }
    private void TryDamage(Health targetHealth)
    {
        targetHealth.Damage(Damage, transform.gameObject);
        Debug.Log("hit" + targetHealth);
        OnHit?.Invoke();
    }
}
