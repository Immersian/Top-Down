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
        else
        {
            CurrentWeapon.StopShoot();
        }
    }
    public void EquipWeapon(GameObject equipWeapon)
    {
        if (equipWeapon == null)
            return;

        if (CurrentWeapon != null)
        {
            // Check if the CurrentWeapon is not null before destroying
            Destroy(CurrentWeapon.gameObject);
        }

        // Instantiate the new weapon with GunPosition as parent
        GameObject weaponGO = GameObject.Instantiate(equipWeapon, GunPosition.position, GunPosition.rotation, GunPosition);
        Weapon weapon = weaponGO.GetComponent<Weapon>();

        // Check if the instantiated object has the Weapon component
        if (weapon == null)
            return;

        CurrentWeapon = weapon;

        Debug.Log("Weapon equipped in WeaponHandler");
    }
}
