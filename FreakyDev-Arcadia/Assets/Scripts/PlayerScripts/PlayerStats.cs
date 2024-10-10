using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int level = 1;
    public int experience = 0;
    public int experienceToNextLevel = 100;

    public int strength;
    public int defense;
    public int intelligence;

    void Start()
    {
        // Initialize stats based on level
        UpdateStats();
    }

    public void GainExperience(int amount)
    {
        experience += amount;
        if (experience >= experienceToNextLevel)
        {
            LevelUp();
        }
    }

    void LevelUp()
    {
        level++;
        experience = experience - experienceToNextLevel;
        experienceToNextLevel += 50; // Increase required XP for next level
        UpdateStats();
        // Play level-up animation or sound
    }

    void UpdateStats()
    {
        // Increase stats based on level
        strength = level * 5;
        defense = level * 3;
        intelligence = level * 2;
    }
}

