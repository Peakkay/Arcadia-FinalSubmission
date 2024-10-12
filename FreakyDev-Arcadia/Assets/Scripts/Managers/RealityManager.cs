using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealityManager : Singleton<RealityManager>
{
    public RealityState currentReality;

    public void ChangeReality(RealityState newReality)
    {
        currentReality = newReality;
        ApplyRealityEffects();
    }

    private void ApplyRealityEffects()
    {
        // Change visuals, effects, and gameplay mechanics based on currentReality
    }
}
