using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LootDrop : MonoBehaviour
{
    public float DropChance = 10f;
    public GameObject[] RandomLoots;
    private Health _health;
    void Start()
    {
        _health = GetComponent<Health>();
        if (_health == null)
            return;

        _health.OnDeath += DropLoot;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void DropLoot()
    {
        float chance = Random.Range(0, 100);

        Debug.Log("Rolled a " +  chance);
        if (chance > DropChance)
            return;

        int selectedLoot = Random.Range(0, RandomLoots.Length);

        GameObject.Instantiate(RandomLoots[selectedLoot], transform.position, transform.rotation);
    }
}
