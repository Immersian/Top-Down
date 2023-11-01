using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject Projectile;
    public Transform SpawnPos;
    public float Projectile_interval = 0.1f;
    private float _timer = 0.0f;
    private bool _canShoot = true;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_timer < Projectile_interval)
        {
            _timer += Time.deltaTime;
            _canShoot = false;
            return;
        }
        _timer = 0.0f;
        _canShoot = true;
    }

    public void Shoot()
    {
        Debug.Log("heard shooting");

        if(Projectile == null)
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

        Debug.Log("shooting bullet");
        GameObject.Instantiate(Projectile,SpawnPos.position, SpawnPos.rotation);
    }
}
