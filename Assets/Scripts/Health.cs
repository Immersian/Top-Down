using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public delegate void HitEvent(GameObject source);
    public HitEvent Onhit;

    public delegate void ResetEvent();
    public ResetEvent OnHitReset;

    public float MaxHealth = 10f;
    public Cooldown Invulnerable;

    public float CurrentHealth
    {
        get { return _currentHealth; }
    }
    private float _currentHealth = 10f;
    private bool _canDamage = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void ResetInvulnerable()
    {
        if (_canDamage)
            return;
        if (Invulnerable.IsOnCooldown && _canDamage == false)
            return;
        _canDamage = true;
        OnHitReset?.Invoke();
    }
    public void Damage(float damage, GameObject source)
    {
        if (!_canDamage) 
            return;

        _currentHealth -= damage;
        if (_currentHealth <= 0f)
        {
            _currentHealth = 0f;
            Die();
        }

        Invulnerable.StartCooldown();
        _canDamage = false;

        Onhit?.Invoke(source);
    }
    public void Die()
    {
        Destroy(this.gameObject);
    }
}
