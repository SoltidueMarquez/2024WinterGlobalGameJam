using UnityEngine;
using DG.Tweening;

public class Road : MonoBehaviour
{
    [SerializeField, Tooltip("道路移动距离")]private float moveLength;
    [SerializeField, Tooltip("道路移动时间")]private float duration;
    private Tween twn;
    
    public void Move()
    {
        twn = transform.DOMoveX(transform.position.x + moveLength, duration);
    }
    
    private void Update()
    {
        DestoryRoad();
    }

    private void DestoryRoad()//检测并销毁道路函数
    {
        if (transform.position.x <= RoadManager.Instance.minValueX)//超出长度销毁
        {
            twn.Kill();//销毁动画
            RoadManager.Instance.roadList.Remove(this);//移除列表
            Destroy(gameObject);//销毁物体
        }
    }
}
