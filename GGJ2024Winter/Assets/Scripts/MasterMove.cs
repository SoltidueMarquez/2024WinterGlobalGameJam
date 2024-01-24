using UnityEngine;

public class MasterMove : MonoBehaviour
{
    public DogMove dogMove; // 对 DogMove 脚本的引用
    public float delayTime; // 主人移动到新跑道的延迟时间
    private float time = 0; // 用于追踪时间的变量
    private int lastDogLane; // 记录狗最后所在的跑道
    private float targetLane; // 主人的目标跑道
    private void Start()
    {
        targetLane = transform.position.y;
    }
    void Update()
    {
        // 检测狗是否移动到了新的跑道
        if (dogMove.GetCurrentRoadIndex() != lastDogLane)
        {
            // 更新狗的当前跑道
            lastDogLane = dogMove.GetCurrentRoadIndex();
            // 重置计时器
            time = 0;
        }

        // 延时逻辑
        if (time < delayTime)
        {
            // 增加时间
            time += Time.deltaTime;
        }
        else
        {
            // 更新主人的目标跑道
            targetLane = dogMove.transform.position.y;
            // 移动主人到目标跑道
            MoveToLane(targetLane);
        }
    }

    private void MoveToLane(float lane)
    {
        Vector3 targetPosition = new Vector3(transform.position.x, lane, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * 5);
    }
}

