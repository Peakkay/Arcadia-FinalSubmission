using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusEffectHandler : MonoBehaviour
{
    private Coroutine poisonCoroutine;

    public void StartPoison(float duration, int damagePerSecond)
    {
        if (poisonCoroutine != null)
        {
            StopCoroutine(poisonCoroutine);
        }
        poisonCoroutine = StartCoroutine(Poison(duration, damagePerSecond));
    }

    public void StopPoison()
    {
        if (poisonCoroutine != null)
        {
            StopCoroutine(poisonCoroutine);
            poisonCoroutine = null;
        }
    }

    IEnumerator Poison(float duration, int damagePerSecond)
    {
        float elapsed = 0f;

        while (elapsed < duration)
        {
            // Apply damage
            GetComponent<PlayerController>().TakeDamage(damagePerSecond);
            yield return new WaitForSeconds(1f);
            elapsed += 1f;
        }
    }
}

