using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Materializer{
    // Private members
    static Dictionary<string, Material> _map;

    static Materializer()
    {
        _map = new Dictionary<string, Material>();
        InitMats();
    }

    public static Material GetMaterial(string key)
    {
        return _map.ContainsKey(key) ? _map[key] : null;
    }

    static void InitMats()
    {
        _map = new Dictionary<string, Material>();
        Material[] mats = Resources.LoadAll<Material>("materials");
        foreach (Material m in mats)
        {
            _map.Add(m.name, m);
        }
    }
}
