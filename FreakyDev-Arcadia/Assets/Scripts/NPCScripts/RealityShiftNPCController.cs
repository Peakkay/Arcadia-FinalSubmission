using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealityShiftNPCController : NPCController
{
    public Reality shiftReality;

public override void Interact()
{
    base.Interact();
    Debug.Log("Shift Called");
    
    if (RealityManager.Instance == null)
    {
        Debug.LogError("RealityManager Instance is null!");
        return;
    }

    if (!RealityManager.Instance.realityStates.ContainsKey(shiftReality))
    {
        Debug.LogError($"Reality state for {shiftReality} not found!");
        return;
    }
    
    RealityManager.Instance.PerformRealityShift(RealityManager.Instance.realityStates[shiftReality]);
}

}
