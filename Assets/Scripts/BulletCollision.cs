using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    public int damage;
    public GameObject[] DamagableFeedback;
    public GameObject[] AnythingFeedback;
    public LayerMask TargetLayerMask;

    private void OnTriggerEnter2D(Collider2D col)
    {
        
        if (((TargetLayerMask.value & (1 << col.gameObject.layer)) > 0))
        {
            HitDamageable(col);
        }
        else
        {
            HitAnything(col);
        }
    }
    private void HitDamageable(Collider2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            Health enemyHealth = col.gameObject.GetComponent<Health>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
            }
            SpawnFeedBack(DamagableFeedback);
            Destroy(gameObject);
        }
    }
    private void HitAnything(Collider2D col)
    {
        if (col.gameObject.CompareTag("Wall"))
        {
            SpawnFeedBack(AnythingFeedback);

            Destroy(gameObject);
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

