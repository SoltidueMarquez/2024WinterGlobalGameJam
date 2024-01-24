using System.Collections.Generic;
using UnityEngine;

public class BalanceController : MonoBehaviour
{
    [System.Serializable]
    public class Rigidbody2DForce
    {
        public Rigidbody2D rigidbody2D;
        public float force;
        public Vector2 direction = Vector2.up;
        public Vector2 point;
        public bool useGlobalDirection = true;
    }

    public Transform head;
    public float rayLength = 1f;
    public LayerMask groundLayer;
    public List<Rigidbody2DForce> allRigidBodiesForces = new List<Rigidbody2DForce>();

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(head.position, Vector2.down, rayLength, groundLayer);
        if (hit.collider != null)
        {
            // 遍历所有关节
            foreach (Rigidbody2DForce rbForce in allRigidBodiesForces)
            {
                Vector2 forceDirection = rbForce.useGlobalDirection ? rbForce.direction : rbForce.rigidbody2D.transform.TransformDirection(rbForce.direction);
                Vector2 worldPoint = rbForce.rigidbody2D.transform.TransformPoint(rbForce.point); // 将局部坐标转换为世界坐标
                // 对每个关节施加相应的力和方向
                rbForce.rigidbody2D.AddForceAtPosition(forceDirection.normalized * rbForce.force, worldPoint, ForceMode2D.Force);
            }
        }
    }

    private void OnDrawGizmos()
    {
        // 可视化射线检测和力的方向
        if (head != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(head.position, head.position + Vector3.down * rayLength);
        }

        foreach (Rigidbody2DForce rbForce in allRigidBodiesForces)
        {
            if (rbForce.rigidbody2D != null)
            {
                Vector3 forceDirection = rbForce.useGlobalDirection ? (Vector3)rbForce.direction : rbForce.rigidbody2D.transform.TransformDirection(rbForce.direction);
                Vector3 worldPoint = rbForce.rigidbody2D.transform.TransformPoint(rbForce.point);
                Gizmos.color = Color.blue;
                Gizmos.DrawLine(worldPoint, worldPoint + forceDirection.normalized * 0.5f); // 将力的方向可视化
                Gizmos.DrawSphere(worldPoint, 0.05f); // 在力的作用点绘制一个小球
            }
        }
    }
}



