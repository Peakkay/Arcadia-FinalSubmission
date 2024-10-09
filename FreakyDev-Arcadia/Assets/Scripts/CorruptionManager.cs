using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorruptionManager : Singleton<CorruptionManager>
{
    public float corruptionLevel = 0f;

    public void IncreaseCorruption(float amount)
    {
        corruptionLevel += amount;
        // Handle corruption effects
    }
}

