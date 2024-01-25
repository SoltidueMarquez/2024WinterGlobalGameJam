using System.Collections.Generic;
using UnityEngine;

public class InstantiatePrefab : MonoBehaviour
{
    public List<PrefabSpawnSettings> spawnSettings;
    public int[] spawnOrder;
    private Dictionary<GameObject, float> spawnTimers = new Dictionary<GameObject, float>();
    private Dictionary<GameObject, float> nextSpawnTimes = new Dictionary<GameObject, float>();
    private int spawnOrderIndex = 0;

    private void Start()
    {
        foreach (var setting in spawnSettings)
        {
            SetNextSpawnTime(setting.prefab);
        }
    }
    private void Update()
    {
        var currentPrefabSetting = spawnSettings[spawnOrder[spawnOrderIndex]];
        if (!spawnTimers.ContainsKey(currentPrefabSetting.prefab))
            spawnTimers[currentPrefabSetting.prefab] = 0;
        spawnTimers[currentPrefabSetting.prefab] += Time.deltaTime;
        if (spawnTimers[currentPrefabSetting.prefab] >= nextSpawnTimes[currentPrefabSetting.prefab])
        {
            Spawn(currentPrefabSetting.prefab);
            SetNextSpawnTime(currentPrefabSetting.prefab);

            spawnOrderIndex = (spawnOrderIndex + 1) % spawnOrder.Length;
        }
    }
    private void Spawn(GameObject prefab)
    {
        Instantiate(prefab, transform.position, Quaternion.identity);
        spawnTimers[prefab] = 0;
    }

    private void SetNextSpawnTime(GameObject prefab)
    {
        var setting = spawnSettings.Find(s => s.prefab == prefab);
        nextSpawnTimes[prefab] = Random.Range(setting.minSpawnInterval, setting.maxSpawnInterval);
    }
}

