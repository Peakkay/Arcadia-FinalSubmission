using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridVisualizer : MonoBehaviour
{
    public int width = 10; // Number of tiles in width
    public int height = 10; // Number of tiles in height
    public float tileSize = 1.0f; // Size of each tile

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red; // Change color as needed

        for (int x = -10; x < 10; x++)
        {
            for (int y = -10; y < 10; y++)
            {
                // Draw a wire cube for each tile
                Gizmos.DrawWireCube(new Vector3(x * tileSize, y * tileSize), new Vector3(tileSize, tileSize, 0.1f));
            }
        }
    }
}

