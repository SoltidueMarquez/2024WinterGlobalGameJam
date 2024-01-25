using UnityEngine;

public class PlayerRigidBodyMgr : MonoBehaviour
{
    public Rigidbody2D[] m_AllRigidBodies;
    public Rigidbody2D m_HipRigidBody;

    private void Awake()
    {
        IgnoreCollision();
    }
    public void IgnoreCollision()
    {
        for (int i = 0; i < m_AllRigidBodies.Length - 1; i++)
        {
            for (int j = i + 1; j < m_AllRigidBodies.Length; j++)
            {
                Collider2D collider1 = m_AllRigidBodies[i].GetComponent<Collider2D>();
                Collider2D collider2 = m_AllRigidBodies[j].GetComponent<Collider2D>();
                if (collider1 != null && collider2 != null)
                {
                    Physics2D.IgnoreCollision(collider1, collider2, true);
                }
            }
        }
    }
}
