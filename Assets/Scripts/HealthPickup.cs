using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : InteractGun
{
    public float HealAmount = 3f;

    protected override void PickedUp(Collider2D collider)
    {
        PlayerHealth health = collider.GetComponent<PlayerHealth>();

        if (health == null)
            return;

        health.Heal(HealAmount);
        Destroy(gameObject);
    }
}
