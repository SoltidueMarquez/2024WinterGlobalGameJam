using UnityEngine;
using System.Collections.Generic;

public class BalanceController : MonoBehaviour
{
    [System.Serializable]
    public class Rigidbody2DForce
    {
        public Rigidbody2D rigidbody2D;
        public float force;
        public Vector2 direction = Vector2.up; // 默认方向为向上
        public Vector2 point; // 力的作用点，相对于刚体的局部坐标
        public bool useGlobalDirection = true; // 是否使用全局方向
    }

    public Transform head; // 火柴人头部的Transform
    public float rayLength = 1f; // 射线检测的长度
    public LayerMask groundLayer; // 地面层
    public List<Rigidbody2DForce> allRigidBodiesForces = new List<Rigidbody2DForce>(); // 所有关节及其力的列表

    private void Update()
    {
        // 从头部中心向下发射射线
        RaycastHit2D hit = Physics2D.Raycast(head.position, Vector2.down, rayLength, groundLayer);

        // 如果射线检测到地面
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



