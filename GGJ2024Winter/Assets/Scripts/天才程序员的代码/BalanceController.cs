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
            // �������йؽ�
            foreach (Rigidbody2DForce rbForce in allRigidBodiesForces)
            {
                Vector2 forceDirection = rbForce.useGlobalDirection ? rbForce.direction : rbForce.rigidbody2D.transform.TransformDirection(rbForce.direction);
                Vector2 worldPoint = rbForce.rigidbody2D.transform.TransformPoint(rbForce.point); // ���ֲ�����ת��Ϊ��������
                // ��ÿ���ؽ�ʩ����Ӧ�����ͷ���
                rbForce.rigidbody2D.AddForceAtPosition(forceDirection.normalized * rbForce.force, worldPoint, ForceMode2D.Force);
            }
        }
    }

    private void OnDrawGizmos()
    {
        // ���ӻ����߼������ķ���
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
                Gizmos.DrawLine(worldPoint, worldPoint + forceDirection.normalized * 0.5f); // �����ķ�����ӻ�
                Gizmos.DrawSphere(worldPoint, 0.05f); // ���������õ����һ��С��
            }
        }
    }
}



