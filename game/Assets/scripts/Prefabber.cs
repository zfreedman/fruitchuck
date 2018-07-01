using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prefabber : MonoBehaviour
{
    // Private members
    Dictionary<string, GameObject> _map;

	// Use this for initialization
	void Awake ()
    {
        InitPrefabs();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public GameObject GetPrefab(string key)
    {
        return _map.ContainsKey(key) ? _map[key] : null;
    }

    public List<GameObject> GetPrefabs(List<string> keyList)
    {
        List<GameObject> prefabs = new List<GameObject>();
        for (int i = 0; i < keyList.Count; ++i)
        {
            prefabs.Add(_map.ContainsKey(keyList[i]) ? _map[keyList[i]] : null);
        }
        return prefabs;
    }

    void InitPrefabs()
    {
        _map = new Dictionary<string, GameObject>();
        GameObject[] prefabs = Resources.LoadAll<GameObject>("prefabs");
        foreach (GameObject p in prefabs)
        {
            _map.Add(p.name, p);
            print(p.name);
        }
    }
}
