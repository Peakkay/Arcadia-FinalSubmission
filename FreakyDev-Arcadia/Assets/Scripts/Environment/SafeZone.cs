using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerStats playerStats = other.GetComponent<PlayerStats>();
            if (playerStats != null)
            {
                // Restore full health and mana instantly
                playerStats.RestoreFullHealthAndMana();
                Debug.Log("Player fully restored in safe zone!");
            }
        }
    }
}
