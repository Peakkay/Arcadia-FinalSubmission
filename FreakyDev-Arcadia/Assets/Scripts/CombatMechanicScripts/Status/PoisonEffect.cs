using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Poison Effect", menuName = "Status Effects/Poison")]
public class PoisonEffect : StatusEffect
{
    public int damagePerSecond;

    public override void ApplyEffect(GameObject target)
    {
        target.GetComponent<StatusEffectHandler>().StartPoison(duration, damagePerSecond);
    }

    public override void RemoveEffect(GameObject target)
    {
        target.GetComponent<StatusEffectHandler>().StopPoison();
    }
}

