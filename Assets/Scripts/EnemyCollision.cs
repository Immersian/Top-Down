using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    //public int damage = 1;
    //public LayerMask TargetLayerMask;
    //private void OnTriggerEnter2D(Collider2D col)
    //{

    //    if (((TargetLayerMask.value & (1 << col.gameObject.layer)) > 0))
    //    {
    //        HitDamageable(col);
    //    }
    //}
    //private void HitDamageable(Collider2D col)
    //{
    //    if (col.gameObject.CompareTag("Player"))
    //    {
    //        Debug.Log("Enemy collided with player.");
    //        PlayerHealth playerHealth = col.gameObject.GetComponent<PlayerHealth>();
    //        if (playerHealth != null)
    //        {
    //            playerHealth.TakeDamage(damage);
    //            Debug.Log("Player took damage. Current health: " + playerHealth.health);
    //        }
    //    }
    //}
    public PlayerHealth playerHealth;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerHealth.TakeDamage(1);
        }
    }
}
