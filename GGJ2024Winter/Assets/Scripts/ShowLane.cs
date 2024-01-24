using UnityEngine;

public class ShowLane : MonoBehaviour
{
    public float radius = 0.2f;
    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(new Vector3(transform.position.x, transform.position.y, transform.position.z), radius);

    }
}
