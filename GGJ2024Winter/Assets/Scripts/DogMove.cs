using UnityEngine;
enum directions { up, down };
public class DogMove : MonoBehaviour
{
    public GameObject[] roadNumberPosition; // �ܵ���λ������
    [SerializeField] private int currentRoadIndex = 1; // ��ǰ�ܵ�������Ĭ�����м��ܵ�
    private int target = 1; // Ŀ���ܵ����

    void Update()
    {
        // ��ⰴ�����벢����Ŀ���ܵ�
        if (Input.GetKeyDown(KeyCode.W))
        {
            ChangeLane(directions.up);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            ChangeLane(directions.down);
        }

        // �ƶ���Ŀ���ܵ�λ��
        MoveToTargetLane();
    }

    private void ChangeLane(directions dir)
    {
        if (dir == directions.up && currentRoadIndex > 0)
        {
            // �����л��ܵ�
            currentRoadIndex--;
        }
        else if (dir == directions.down && currentRoadIndex < roadNumberPosition.Length - 1)
        {
            // �����л��ܵ�
            currentRoadIndex++;
        }

        target = currentRoadIndex; // ����Ŀ���ܵ�
    }

    private void MoveToTargetLane()
    {
        // ������������ʵ�ʵ��ƶ��߼�������ʹ�� DoTween ��ƽ���ƶ���Ŀ��λ��
        Vector3 targetPosition = new Vector3(transform.position.x, roadNumberPosition[target].transform.position.y, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * 5);
    }
    public int GetCurrentRoadIndex()
    {
        return currentRoadIndex;
    }
}

