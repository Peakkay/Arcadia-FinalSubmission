using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDialogue", menuName = "Dialogue")]
public class Dialogue : ScriptableObject
{
    [TextArea(3, 10)] // Optional: For better visibility in the inspector
    public List<string> lines; // Array of dialogue lines
    public int dialogueID;
}
