using BarthaSzabolcs.Tutorial_SpriteFlash;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public SimpleFlash flash;
    public int maxHealth = 10;
    public int health;
    public delegate void DeathEvent();
    public DeathEvent OnDeath;

    [SerializeField] FloatingHealthBar healthBar;

    private void Awake()
    {
        healthBar = GetComponentInChildren<FloatingHealthBar>();
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
        if (health <= 0) 
        {
            Die();
        }
        flash.Flash();

    }
    public void Die()
    {
        OnDeath?.Invoke();
        Destroy(gameObject);
    }
}
