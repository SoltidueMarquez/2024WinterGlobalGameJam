using UnityEngine;

public class Bones : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.CompareTag("Dog"))
        {
            ObjectManager.Instance.bonesNum++;
            Destroy(gameObject);//销毁物体
        }
    }
}
