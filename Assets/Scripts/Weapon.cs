using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Xml.Serialization;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject Projectile;
    public GameObject MuzzleFlashPrefab;
    public Transform SpawnPos;
    public float Projectile_interval = 0.1f;
    public float MuzzleFlashDuration = 0.1f;
    private bool _canShoot = true;
    public Cooldown AutofireShootInterval;
    public GameObject[] Feedbacks;
    private bool _burstFiring = false;
    private bool _singleFireReset = true;
    public float BurstFireInterval = 0.1f;
    public int BurstFireAmount = 3;
    private float _lastShootRequest;
    public float Spread = 0f;

    // Update is called once per frame
    void Update()
    {
        UpdateShootCooldown();
        UpdateReloadCooldown();
    }
    private void UpdateReloadCooldown()
    {
        if (ReloadCooldown.CurrentProgress != Cooldown.Progress.Finished)
            return;
        if (ReloadCooldown.CurrentProgress == Cooldown.Progress.Finished)
        {
            currentBulletCount = MaxBulletCount;
        }
        ReloadCooldown.CurrentProgress = Cooldown.Progress.Ready;
    }
    private void UpdateShootCooldown()
    {
        if (AutofireShootInterval.CurrentProgress != Cooldown.Progress.Finished)
            return;

        AutofireShootInterval.CurrentProgress = Cooldown.Progress.Ready;
    }


    public enum FireModes
    {
        Auto,
        SingleFire,
        BurstFire,
        Shotgun

    }
    public FireModes FireMode;
    public int ProjectileCount = 1;
    public GameObject[] ReloadFeedbacks;
    public Cooldown ReloadCooldown;
    public int MaxBulletCount = 12;

    public int CurrentBulletCount
    {
        get { return CurrentBulletCount; }
    }
    protected int currentBulletCount;


    private void Start()
    {
        currentBulletCount = MaxBulletCount;
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

        if (ReloadCooldown.IsOnCooldown || ReloadCooldown.CurrentProgress != Cooldown.Progress.Ready)
            return;

        switch (FireMode)
        {
            case FireModes.Auto:
                {
                    AutoFireShoot();
                    break;
                }
                case FireModes.SingleFire:
                {
                    SingleFireShoot();
                    break;
                }
                case FireModes.BurstFire:
                {
                    BurstFireShoot();
                    break;
                }
            case FireModes.Shotgun:
                {
                    Shotgun();
                    break;
                }
        }




        //Debug.Log("shooting bullet");
        //// Instantiate muzzle flash prefab
        //if (MuzzleFlashPrefab != null)
        //{
        //    GameObject muzzleFlash = GameObject.Instantiate(MuzzleFlashPrefab, SpawnPos.position, SpawnPos.rotation);
        //    Destroy(muzzleFlash, MuzzleFlashDuration); 
        //}
        //SpawnFeedback();
    }
    void BurstFireShoot()
    {
        if (!_canShoot)
            return;
        if (_burstFiring)
            return;
        //if (!_singleFireReset) 
        //    return;
        if (AutofireShootInterval.CurrentProgress != Cooldown.Progress.Ready)
            return;


        StartCoroutine(BurstFireCo());
    }
    IEnumerator BurstFireCo()
    {
        _burstFiring = true;
        _singleFireReset = false;

        Debug.Log("starting");

        //if (Time.time - _lastShootRequest < BurstFireInterval)
        //{
        //    Debug.Log("break");

        //    yield break;
        //}

        int remainingShots = BurstFireAmount;

        while (remainingShots > 0)
        {
            ShootProjectile();
            _lastShootRequest = Time.time;

            remainingShots--;
            Debug.Log(remainingShots);

            yield return WaitFor(BurstFireInterval);
        }

        Debug.Log("done");



        _burstFiring = false;

        AutofireShootInterval.StartCooldown();
    }
    IEnumerator WaitFor(float seconds)
    {
        for (float timer = 0f; timer < seconds; timer += Time.deltaTime)
        {
            yield return null;
        }
    }
    void ShootProjectile()
    {
        float randomRot = Random.Range(-Spread, Spread);
        GameObject bullet = GameObject.Instantiate(Projectile, SpawnPos.position, SpawnPos.rotation);
        SpawnFeedback();
    }
    void ShootProjectileSpread()
    {
        GameObject bullet = GameObject.Instantiate(Projectile, SpawnPos.position, SpawnPos.rotation);

        Quaternion rotationOffset = Quaternion.Euler(0.0f, 0.0f, 20.0f); 
        Quaternion rotationOffset3 = Quaternion.Euler(0.0f, 0.0f, -20.0f); 

        GameObject bullet2 = GameObject.Instantiate(Projectile, SpawnPos.position, SpawnPos.rotation * rotationOffset);
        GameObject bullet3 = GameObject.Instantiate(Projectile, SpawnPos.position, SpawnPos.rotation * rotationOffset3);

        SpawnFeedback();
    }

    void AutoFireShoot()
    {
        if (!_canShoot)
            return;

        if (AutofireShootInterval.CurrentProgress != Cooldown.Progress.Ready)
            return;


        ShootProjectile();

        AutofireShootInterval.StartCooldown();

        currentBulletCount--;
        StartReloading();
    }
    void StartReloading()
    {
        if (currentBulletCount <= 0 && !ReloadCooldown.IsOnCooldown)
        {
            foreach (var feedback in ReloadFeedbacks)
            {
                GameObject.Instantiate(feedback, transform.position, transform.rotation);
            }
            ReloadCooldown.StartCooldown();
        }
    }
    void SingleFireShoot()
    {
        if (!_singleFireReset)
            return;

        ShootProjectile();
        currentBulletCount--;
        _singleFireReset = false;
        StartReloading();

        
    }
    void Shotgun()
    {
        if (!_singleFireReset)
            return;

        ShootProjectileSpread();
        currentBulletCount--;
        _singleFireReset = false;
        StartReloading();
    }
    public void StopShoot()
    {
        _singleFireReset = true;
    }
    void SpawnFeedback()
    {
        foreach (var feedback in Feedbacks)
        {
            GameObject.Instantiate(feedback, SpawnPos.position, SpawnPos.rotation);
        }
    }
}

