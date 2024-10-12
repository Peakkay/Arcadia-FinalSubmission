using UnityEngine;

[CreateAssetMenu(fileName = "NewDialogue", menuName = "Dialogue")]
public class Dialogue : ScriptableObject
{
    [TextArea(3, 10)] // Optional: For better visibility in the inspector
    public string[] lines; // Array of dialogue lines
}
