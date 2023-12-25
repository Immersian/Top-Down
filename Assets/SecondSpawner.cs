using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondSpawner : MonoBehaviour
{
    public GameObject EnemyObject;
    public GameObject NPC;
    private float spawnTimer;
    public float MinSpawnInterval = 1f;
    public float MaxSpawnInterval = 3f;

    public float minX = -1f;
    public float maxX = 1f;

    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = RandomSpawnInterval();
    }

    // Update is called once per frame
    void Update()
    {
        if (NPC == null)
        {
            if (spawnTimer > 0)
            {
                spawnTimer -= Time.deltaTime;
            }
            else
            {
                SpawnEnemy();
                spawnTimer = RandomSpawnInterval();
            }
        }
    }

    void SpawnEnemy()
    {
        float rand = Random.Range(minX, maxX);
        Vector3 randomPos = new Vector3(rand, 0f, 0f);

        if (EnemyObject != null)
        {
            GameObject.Instantiate(EnemyObject, transform.position + randomPos, transform.rotation);
        }

        Debug.Log("Enemy spawned");

    }
    float RandomSpawnInterval()
    {
        return Random.Range(MinSpawnInterval, MaxSpawnInterval);
    }
}
