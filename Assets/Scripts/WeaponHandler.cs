using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    public Weapon CurrentWeapon;
    public Transform GunPosition;

    protected bool _tryShoot = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
        HandleWeapon();
    }
    protected virtual void HandleInput()
    {

    }
    protected virtual void HandleWeapon()
    {
        if (CurrentWeapon == null) 
            return;

        CurrentWeapon.transform.position = GunPosition.position;
        CurrentWeapon.transform.rotation = GunPosition.rotation;

        if (_tryShoot)
        {
            CurrentWeapon.Shoot();
        }
    }
    public void EquipWeapon(Weapon weapon)
    {
        if (weapon == null) return;
        CurrentWeapon = weapon;
    }
}
