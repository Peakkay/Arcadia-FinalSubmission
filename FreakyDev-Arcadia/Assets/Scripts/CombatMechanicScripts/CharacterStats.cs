using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int health;
    public int attackPower;
    public int defense;

    public void TakeDamage(int damage)
    {
        health -= Mathf.Max(damage - defense, 0);
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Handle character death
    }
}

