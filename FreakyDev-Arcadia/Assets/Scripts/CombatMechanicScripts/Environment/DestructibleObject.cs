using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleObject : MonoBehaviour
{
    public int health = 50;
    public GameObject[] lootDrops;

    public void TakeDamage(int damage)
    {
        health -= damage;
        // Play hit animation

        if (health <= 0)
        {
            DestroyObject();
        }
    }

    void DestroyObject()
    {
        // Play destruction animation
        // Instantiate loot drops
        foreach (GameObject loot in lootDrops)
        {
            Instantiate(loot, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}

