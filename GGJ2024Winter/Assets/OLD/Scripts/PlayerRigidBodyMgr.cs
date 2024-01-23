using UnityEngine;

/// <summary>
/// 人物刚体编号管理
/// </summary>
public class PlayerRigidBodyMgr : MonoBehaviour
{
    public Rigidbody2D[] m_AllRigidBodies;
    public Rigidbody2D m_HipRigidBody;

    private void Awake()
    {
        InitRigidBodies();
    }

    private void InitRigidBodies() // 初始化刚体，编号
    {
        this.m_AllRigidBodies = base.GetComponentsInChildren<Rigidbody2D>();
        int length = this.m_AllRigidBodies.Length;
        for (int i = 0; i < length; i++)
        {
            Rigidbody2D rigidbody2D = this.m_AllRigidBodies[i];
            // 可以在这里设置编号，例如使用游戏对象的名字
            string rigidBodyName = rigidbody2D.gameObject.name;
            Debug.Log("Rigidbody #" + i + ": " + rigidBodyName);
        }
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
