using UnityEngine;
public struct myColor { public float R, G, B; };
public class ShowPiont : MonoBehaviour
{
    public float radius = 0.2f;
    public Color color;
    void OnDrawGizmos()
    {

        Gizmos.color = color;
        Gizmos.DrawSphere(new Vector3(transform.position.x, transform.position.y, transform.position.z), radius);
    }
}
