using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellManager : Singleton<SpellManager>
{
    public List<Spell> spells = new List<Spell>(); // List to hold spell Scriptable Objects

    // Method to add a spell to the list (optional)
    public void AddSpell(Spell spell)
    {
        if (!spells.Contains(spell)) // Ensure no duplicates
        {
            spells.Add(spell);
            Debug.Log($"Spell added: {spell.spellName} with ID {spell.spellID}");
        }
        else
        {
            Debug.LogWarning("Spell already exists!");
        }
    }

    // Method to get a spell by ID
    public Spell GetSpellByID(int id)
    {
        return spells.Find(s => s.spellID == id);
    }

    // Method to cast a spell by ID
// Method to cast a spell by ID
    public void CastSpell(int spellID, Enemy targetEnemy)
    {
        Spell spell = GetSpellByID(spellID);
        if (spell != null)
        {
            spell.CastSpell(targetEnemy); // Pass the target enemy to the casting method
        }
        else
        {
            Debug.LogWarning("Spell not found!");
        }
    }

}

