using UnityEngine;

public class Road : MonoBehaviour
{
    public void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, RoadManager.Instance.targetPosition, Time.deltaTime * RoadManager.Instance.speed);
        if (transform.position == RoadManager.Instance.targetPosition)
        {
            transform.position = RoadManager.Instance.startPosition;
        }
    }
    private void FixedUpdate()
    {
        Move();
    }
}
