using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat
{
    public int maxHP;              // Maximum health
    public int CurrentHP; // Current health
    public int attackDamage;        // Attack damage
    public int maxMana;            // Maximum mana
    public int CurrentMana; // Current mana
    public float healthRegenRate; // Health regenerated per second
    public float manaRegenRate;   // Mana regenerated per second

    public void AddStat(Stat statchange)
    {
        maxHP += statchange.maxHP;
        CurrentHP += statchange.CurrentHP;
        attackDamage += statchange.attackDamage;
        maxMana += statchange.maxMana;
        CurrentMana += statchange.CurrentMana;
        healthRegenRate += statchange.healthRegenRate;
        manaRegenRate += statchange.manaRegenRate;
    }

    public void RemoveStat(Stat statchange)
    {
        maxHP -= statchange.maxHP;
        CurrentHP -= statchange.CurrentHP;
        attackDamage -= statchange.attackDamage;
        maxMana -= statchange.maxMana;
        CurrentMana -= statchange.CurrentMana;
        healthRegenRate -= statchange.healthRegenRate;
        manaRegenRate -= statchange.manaRegenRate;
    }
}
