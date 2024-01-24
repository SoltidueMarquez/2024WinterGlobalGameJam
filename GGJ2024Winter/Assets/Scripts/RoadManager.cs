using System.Collections.Generic;
using UnityEngine;

public class RoadManager : Singleton<RoadManager>
{
    public float minValueX;
    public List<Road> roadList;
    [SerializeField, Tooltip("同时存在道路数量")] private int roadCount;


    private void Start()
    {
        for (int i = 0; i < roadList.Count; i++)
        {
            roadList[i].Move();
        }
    }

    private void Update()
    {
        if (roadList.Count <= roadCount)
        {

        }
    }
}
