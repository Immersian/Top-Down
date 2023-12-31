using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] Monsters;
    public float MinX = -10;
    public float MaxX = 10;

    public float MinY = -6;
    public float MaxY = 6;

    public Transform Top;
    public Transform Bot;
    public Transform Left;
    public Transform Right;

    public float MinSpawnCooldown = 0.5f;
    public float MaxSpawnCooldown = 2f;

    protected float _spawnTimer = 0f;

    // Update is called once per frame
    void Update()
    {
        if (_spawnTimer > 0)
        {
            _spawnTimer -= Time.deltaTime;
            return;
        }

        int randomSpawnPos = Random.Range(0, 3);
        int randomIndex = Random.Range(0, Monsters.Length);

        switch (randomSpawnPos)
        {
            case (0):
                Instantiate(Monsters[randomIndex], Top.position + new Vector3(Random.Range(MinX, MaxX), 0), transform.rotation);
                break;
        }
        

        _spawnTimer = Random.Range(MinSpawnCooldown, MaxSpawnCooldown);
    }
}
