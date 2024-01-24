using UnityEngine;
enum directions { up, down };
public class DogMove : MonoBehaviour
{
    public GameObject[] roadNumberPosition; // 跑道的位置数组
    [SerializeField] private int currentRoadIndex = 1; // 当前跑道索引，默认在中间跑道
    private int target = 1; // 目标跑道编号

    void Update()
    {
        // 检测按键输入并更新目标跑道
        if (Input.GetKeyDown(KeyCode.W))
        {
            ChangeLane(directions.up);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            ChangeLane(directions.down);
        }

        // 移动到目标跑道位置
        MoveToTargetLane();
    }

    private void ChangeLane(directions dir)
    {
        if (dir == directions.up && currentRoadIndex > 0)
        {
            // 向上切换跑道
            currentRoadIndex--;
        }
        else if (dir == directions.down && currentRoadIndex < roadNumberPosition.Length - 1)
        {
            // 向下切换跑道
            currentRoadIndex++;
        }

        target = currentRoadIndex; // 更新目标跑道
    }

    private void MoveToTargetLane()
    {
        // 这里你可以添加实际的移动逻辑，比如使用 DoTween 来平滑移动到目标位置
        Vector3 targetPosition = new Vector3(transform.position.x, roadNumberPosition[target].transform.position.y, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * 5);
    }
    public int GetCurrentRoadIndex()
    {
        return currentRoadIndex;
    }
}

