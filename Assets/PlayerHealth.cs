//using BarthaSzabolcs.Tutorial_SpriteFlash;
using BarthaSzabolcs.Tutorial_SpriteFlash;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics;

public class PlayerHealth : MonoBehaviour
{
    //public SimpleFlash flash;
    public float maxHealth = 10f;
    public float health;
    public delegate void HealEvent(GameObject source);
    public static HealEvent OnHeal;
    [SerializeField] FloatingHealthBar healthBar;
    public SimpleFlash flash;

    private void Awake()
    {
        if (healthBar == null)
        {
            healthBar = GameObject.Find("PlayerHealthBar").GetComponentInChildren<FloatingHealthBar>();
        }
    }

    private void Start()
    {
        health = maxHealth;
        healthBar.UpdateHealthBar(health, maxHealth);
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        healthBar.UpdateHealthBar(health, maxHealth);
        flash.Flash();

    }
    public void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void Heal(float healAmount)
    {
        health += healAmount;
        health = Mathf.Clamp(health, 0, maxHealth);
        OnHeal?.Invoke(gameObject);
        healthBar.UpdateHealthBar(health, maxHealth); // Call the update here as well
    }
}


