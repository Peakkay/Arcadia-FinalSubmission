using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spell : ScriptableObject
{
    public string spellName;
    public Sprite spellIcon;
    public float manaCost;
    public float cooldownTime;

    public abstract void Cast(GameObject caster);
}

