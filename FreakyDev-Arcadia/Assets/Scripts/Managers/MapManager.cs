using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : Singleton<MapManager>
{
    public List<GameObject> Maps;
    public int currentMap;

    public void Start()
    {
        currentMap = 4;
    }
    public void ChangeMap(int MapID)
    {
        foreach(var map in Maps)
        {
            map.SetActive(false);
        }
        Maps[MapID].SetActive(true);
        currentMap = MapID;
    }

    public void NoMap()
    {
        foreach(var map in Maps)
        {
            map.SetActive(false);
        }
        currentMap = -1;
    }
}

