using UnityEngine;


/// <summary>
/// ������ײ��
/// </summary>
public class x_PunchForce : MonoBehaviour
{
    public bool IsCollisionGround = false;
    public bool IsCollisionWall = false;
    [HideInInspector]
    public Vector3 groundPoint; //������ײ��
    [HideInInspector]
    public Vector3 wallPoint;   //ǽ����ײ��
    [HideInInspector]
    public Vector3 wallnormal;  //��ײ���߷���

    [HideInInspector]
    public float m_StemEmptyTime;
    public float m_StemEmptyTimer;//�ȿ�ʱ��

    private Collider2D _collider;
    
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.root == base.transform.root) //������Լ����Լ�������
        {
            return;
        }
        if (collision.collider.tag == "Rigidbodys" || collision.collider.tag == "wall")
        {
            return;
        }
        if (Vector3.Angle(Vector3.up, collision.contacts[0].normal) > 95f) //����ײ�巴����
        {
            return;
        }
        _collider = collision.collider;
        if (Vector3.Angle(Vector3.up, collision.contacts[0].normal) < 70 && collision.collider.tag == "Ground")
        {
            IsCollisionGround = true;
            m_StemEmptyTimer = 0;
            groundPoint = collision.contacts[0].point;
        }
        if (Vector3.Angle(Vector3.up, collision.contacts[0].normal) > 75)
        {
            if (collision.collider.tag == "bullet" || collision.collider.tag == "weapon" || collision.collider.tag == "airwall")
                return;
            this.wallnormal = collision.contacts[0].normal;
            IsCollisionWall = true;
            m_StemEmptyTimer = 1;
            wallPoint = collision.contacts[0].point;
        }
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.root == base.transform.root) //������Լ����Լ�������
        {
            return;
        }
        if (collision.collider.CompareTag("Rigidbodys") || collision.collider.tag == "wall")
        {
            return;
        }
        if (Vector3.Angle(Vector3.up, collision.contacts[0].normal) > 95f) //����ײ�巴����
        {
            return;
        }
        _collider = collision.collider;

        if (Vector3.Angle(Vector3.up, collision.contacts[0].normal) < 70 && collision.collider.tag == "Ground")
        {
            IsCollisionGround = true;
            groundPoint = collision.contacts[0].point;
        }
        if (Vector3.Angle(Vector3.up, collision.contacts[0].normal) > 75)
        {
            if (collision.collider.tag == "bullet" || collision.collider.tag == "weapon" || collision.collider.tag == "airwall")
                return;
            this.wallnormal = collision.contacts[0].normal;
            IsCollisionWall = true;
            m_StemEmptyTimer = 1;
            wallPoint = collision.contacts[0].point;
        }
    }


    void OnCollisionExit2D(Collision2D other)
    {
        if (other.transform.root == transform.root)
        {
            return;
        }
        if (other.collider.tag == "Ground" || other.collider.CompareTag("Rigidbodys"))
        {
            IsCollisionGround = false;
            IsCollisionWall = false;
        }
    }

    void Exit()
    {
        IsCollisionGround = false;
        IsCollisionWall = false;
    }

    private void Update()
    {
        if (_collider == null)
        {
            Exit();
        }
        if (!IsCollisionGround)
        {
            m_StemEmptyTimer += Time.deltaTime;
        }
    }
}
