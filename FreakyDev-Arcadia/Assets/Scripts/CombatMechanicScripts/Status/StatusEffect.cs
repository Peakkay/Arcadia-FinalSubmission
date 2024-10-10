using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StatusEffect : ScriptableObject
{
    public string effectName;
    public float duration;

    public abstract void ApplyEffect(GameObject target);
    public abstract void RemoveEffect(GameObject target);
}

