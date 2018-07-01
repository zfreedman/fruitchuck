using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Prefabber
{
    // Private members
    static Dictionary<string, GameObject> _map;

    static Prefabber()
    {
        _map = new Dictionary<string, GameObject>();
        InitPrefabs();
    }

    public static GameObject GetPrefab(string key)
    {
        return _map.ContainsKey(key) ? _map[key] : null;
    }

    public static List<GameObject> GetPrefabs(List<string> keyList)
    {
        List<GameObject> prefabs = new List<GameObject>();
        for (int i = 0; i < keyList.Count; ++i)
        {
            prefabs.Add(_map.ContainsKey(keyList[i]) ? _map[keyList[i]] : null);
        }
        return prefabs;
    }

    static void InitPrefabs()
    {
        _map = new Dictionary<string, GameObject>();
        GameObject[] prefabs = Resources.LoadAll<GameObject>("prefabs/world");
        foreach (GameObject p in prefabs)
        {
            _map.Add(p.name, p);
        }
    }
}
