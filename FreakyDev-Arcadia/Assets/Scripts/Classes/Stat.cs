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

    public void AddStat(Stat statchange)
    {
        maxHP += statchange.maxHP;
        CurrentHP += statchange.CurrentHP;
        attackDamage += statchange.attackDamage;
        maxMana += statchange.maxMana;
        CurrentMana += statchange.CurrentMana;
    }

    public void RemoveStat(Stat statchange)
    {
        maxHP -= statchange.maxHP;
        CurrentHP -= statchange.CurrentHP;
        attackDamage -= statchange.attackDamage;
        maxMana -= statchange.maxMana;
        CurrentMana -= statchange.CurrentMana;
    }
}
