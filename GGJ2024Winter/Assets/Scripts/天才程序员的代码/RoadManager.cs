using UnityEngine;

public class RoadManager : Singleton<RoadManager>
{
    [Tooltip("道路移动距离")] public Vector3 targetPosition;
    [Tooltip("道路移动距离")] public Vector3 startPosition;
    public float speed;
}
