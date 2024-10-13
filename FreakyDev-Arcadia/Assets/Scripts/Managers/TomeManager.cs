using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomeManager : Singleton<TomeManager>
{
    public string tomeName; // Name of the tome
    public List<Spell> spells; // List of spells contained in the tome

    // Method to learn a spell from the tome
    public void LearnSpell(Spell spell)
    {
        if (!spells.Contains(spell))
        {
            spells.Add(spell);
            Debug.Log($"Learned spell: {spell.spellName} from {tomeName}");
        }
        else
        {
            Debug.LogWarning("Spell already known!");
        }
    }

    // Method to get a spell by name
    public Spell GetSpellByName(string name)
    {
        return spells.Find(s => s.spellName == name);
    }

    // Method to cast a spell from the tome
// Method to cast a spell from the tome
    public void CastSpellFromTome(string spellName, Enemy targetEnemy)
    {
        Spell spell = GetSpellByName(spellName);
        if (spell != null)
        {
            spell.CastSpell(targetEnemy); // Pass the target enemy to the casting method
        }
        else
        {
            Debug.LogWarning("Spell not found in tome!");
        }
    }


    // Optional: You can add any other methods for managing spells here
    public void ShowAllSpells()
    {
        foreach (var spell in spells)
        {
            Debug.Log($"Spell in Tome: {spell.spellName}");
        }
    }
}


