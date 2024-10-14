using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RealityManager : Singleton<RealityManager>
{
    public Reality currentReality;
    public GameObject player; // Reference to the player GameObject
    private SpriteRenderer playerSpriteRenderer;
    public RealityState Celestial;
    public RealityState Corrupted;
    public RealityState Normal;
    public Dictionary<Reality,RealityState>realityStates;
    public Dictionary<Reality, Tilemap> realityTilemaps; // A dictionary to hold tilemaps for each reality state
    public Dictionary<Reality, Sprite> realitySprites; // A dictionary to hold sprites for each reality state
    public List<Tilemap> tilemaps;
    public List<Sprite> sprites;
    public List<Reality> reality;
    public int worldCorruption; // The world corruption metric

private void Start()
{
    playerSpriteRenderer = player.GetComponent<SpriteRenderer>();

    // Initialize the realityStates dictionary
    realityStates = new Dictionary<Reality, RealityState>();

    Celestial = new RealityState(Reality.Celestial);
    Normal = new RealityState(Reality.Normal);
    Corrupted = new RealityState(Reality.Corrupted);
    
    realitySprites = new Dictionary<Reality, Sprite>();
    realityTilemaps = new Dictionary<Reality, Tilemap>();
    
    for (int i = 0; i < 3; i++)
    {
        realitySprites[reality[i]] = sprites[i];
        realityTilemaps[reality[i]] = tilemaps[i];
    }

    // Populate realityStates dictionary
    realityStates[Reality.Celestial] = Celestial;
    realityStates[Reality.Normal] = Normal;
    realityStates[Reality.Corrupted] = Corrupted;
}


    public void PerformRealityShift(RealityState realityState)
    {
        // Change player sprite
        Debug.Log($"Reality shift Called to {realityState.reality}");
        ChangePlayerSprite(realityState);

        // Adjust World Corruption
        RealityManager.Instance.AdjustWorldCorruption(realityState.CorruptionOffset);

        // Change the tilemap
        ChangeTilemap(realityState);
    }

private void ChangePlayerSprite(RealityState realityState)
{
    if (realitySprites.TryGetValue(realityState.reality, out Sprite newSprite))
    {
        playerSpriteRenderer.sprite = newSprite;
        Debug.Log($"Player sprite changed to {realityState.reality} state.");
    }
}


private void ChangeTilemap(RealityState realityState)
{
    foreach (var tilemap in realityTilemaps.Values)
    {
        tilemap.gameObject.SetActive(false); // Hide all tilemaps
    }

    if (realityTilemaps.TryGetValue(realityState.reality, out Tilemap activeTilemap))
    {
        activeTilemap.gameObject.SetActive(true); // Activate the corresponding tilemap
        Debug.Log($"Tilemap changed to {realityState.reality} state.");
    }
}

    public void AdjustWorldCorruption(int corruptionChange)
    {
        worldCorruption += corruptionChange;
        Debug.Log($"World Corruption adjusted by {corruptionChange}. New value: {worldCorruption}");
    }

}
