using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    public int damage;
    public GameObject[] DamagableFeedback;
    public GameObject[] AnythingFeedback;
    public LayerMask TargetLayerMask;
    public float PushForce = 1f;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (((TargetLayerMask.value & (1 << col.gameObject.layer)) > 0))
        {
            HitDamageable(col.gameObject);
        }
        else
        {
            HitAnything(col.gameObject);
        }
    }

    private void HitDamageable(GameObject target)
    {
        if (target.CompareTag("Enemy"))
        {
            Health enemyHealth = target.GetComponent<Health>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
                ApplyKnockback(target);
            }
            SpawnFeedBack(DamagableFeedback);
            Destroy(gameObject);
        }
    }

    private void HitAnything(GameObject target)
    {
        if (target.CompareTag("Wall"))
        {
            SpawnFeedBack(AnythingFeedback);
            Destroy(gameObject);
        }
    }

    private void ApplyKnockback(GameObject target)
    {
        Rigidbody2D targetRigidbody = target.GetComponent<Rigidbody2D>();
        if (targetRigidbody != null)
        {
            Vector2 knockbackDirection = (target.transform.position - transform.position).normalized;
            targetRigidbody.AddForce(knockbackDirection * PushForce, ForceMode2D.Impulse);
        }
    }

    void SpawnFeedBack(GameObject[] Feedbacks)
    {
        foreach (var feedback in Feedbacks)
        {
            GameObject.Instantiate(feedback, transform.position, transform.rotation);
        }
    }
}


