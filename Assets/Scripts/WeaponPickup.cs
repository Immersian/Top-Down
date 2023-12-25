using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : InteractGun
{
    public GameObject Weapon;

    protected override void PickedUp(Collider2D collider)
    {
        Debug.Log(collider.gameObject);

        WeaponHandler weaponHandler = collider.GetComponent<WeaponHandler>();

        if (weaponHandler == null)
            return;

        Debug.Log("test");
        // Equip the weapon and instantiate pickup feedbacks
        weaponHandler.EquipWeapon(Weapon);
    }
}
