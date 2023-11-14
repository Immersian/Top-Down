using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject Projectile;
    public GameObject MuzzleFlashPrefab;
    public Transform SpawnPos;
    public float Projectile_interval = 0.1f;
    public float MuzzleFlashDuration = 0.1f;
    private float _timer = 0.0f;
    private bool _canShoot = true;
    public Cooldown AutofireShootInterval;

    // Update is called once per frame
    void Update()
    {
        if (AutofireShootInterval.CurrentProgress != Cooldown.Progress.Finished)
            return;

        AutofireShootInterval.CurrentProgress = Cooldown.Progress.Ready;
    }

    public void Shoot()
    {
        Debug.Log("heard shooting");

        if (Projectile == null)
        {
            Debug.Log("Missing projectile prefab");
            return;
        }

        if (SpawnPos == null)
        {
            Debug.Log("Missing SpawnPosition transform");
            return;
        }

        if (!_canShoot)
        {
            return;
        }

        if (AutofireShootInterval.CurrentProgress != Cooldown.Progress.Ready)
            return;
        GameObject bullet = GameObject.Instantiate(Projectile, SpawnPos.position, SpawnPos.rotation);
        GameObject bullet1= GameObject.Instantiate(Projectile, SpawnPos.position, SpawnPos.rotation);
        GameObject bullet2= GameObject.Instantiate(Projectile, SpawnPos.position, SpawnPos.rotation);
        GameObject bullet3= GameObject.Instantiate(Projectile, SpawnPos.position, SpawnPos.rotation);
        GameObject bullet4= GameObject.Instantiate(Projectile, SpawnPos.position, SpawnPos.rotation);

        AutofireShootInterval.StartCooldown();




        Debug.Log("shooting bullet");
        // Instantiate muzzle flash prefab
        if (MuzzleFlashPrefab != null)
        {
            GameObject muzzleFlash = GameObject.Instantiate(MuzzleFlashPrefab, SpawnPos.position, SpawnPos.rotation);
            Destroy(muzzleFlash, MuzzleFlashDuration); 
        }
    }
}

