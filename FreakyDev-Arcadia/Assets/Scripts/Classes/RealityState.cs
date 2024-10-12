using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealityState
{
    public string name;
    public Reality reality;
    public List<string> effects; // Effects that apply in this state
    public Color backgroundColor; // Change background based on state
    // Add more properties as needed
    public RealityState(Reality reality)
    {
        this.reality = reality;
    }
}

public enum Reality
{
    Normal,
    Corrupted,
    Celestial
}



