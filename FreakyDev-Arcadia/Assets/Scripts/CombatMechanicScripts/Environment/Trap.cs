using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public int damage = 20;
    public float activationDelay = 1f;
    private bool isActive = true;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (isActive && other.CompareTag("Player"))
        {
            StartCoroutine(ActivateTrap(other));
        }
    }

    IEnumerator ActivateTrap(Collider2D player)
    {
        isActive = false;
        // Play trap activation animation
        yield return new WaitForSeconds(activationDelay);
        player.GetComponent<PlayerController>().TakeDamage(damage);
        // Reactivate trap after a delay if needed
        isActive = true;
    }
}

