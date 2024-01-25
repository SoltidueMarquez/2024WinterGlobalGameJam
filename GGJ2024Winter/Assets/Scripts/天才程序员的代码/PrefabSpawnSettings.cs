using UnityEngine;

[System.Serializable]
public struct PrefabSpawnSettings
{
    public GameObject prefab;
    public float minSpawnInterval;
    public float maxSpawnInterval;
}
