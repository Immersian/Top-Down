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
    private PlayerHealth playerHealth;
    public float damageCooldown = 10f; // Time between damage ticks
    private float nextDamageTime = 0f;
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Base")
        {
            if (Time.time >= nextDamageTime)
            {
                playerHealth = (PlayerHealth)collision.gameObject.GetComponent<PlayerHealth>();

                if (playerHealth == null)
                    return;

                playerHealth.TakeDamage(1);
                nextDamageTime = Time.time + damageCooldown;
            }
        }
    }
}
