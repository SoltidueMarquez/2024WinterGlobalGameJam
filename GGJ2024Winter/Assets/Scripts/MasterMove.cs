using UnityEngine;

public class MasterMove : MonoBehaviour
{
    public DogMove dogMove; // �� DogMove �ű�������
    public float delayTime; // �����ƶ������ܵ����ӳ�ʱ��
    private float time = 0; // ����׷��ʱ��ı���
    private int lastDogLane; // ��¼��������ڵ��ܵ�
    private float targetLane; // ���˵�Ŀ���ܵ�
    private void Start()
    {
        targetLane = transform.position.y;
    }
    void Update()
    {
        // ��⹷�Ƿ��ƶ������µ��ܵ�
        if (dogMove.GetCurrentRoadIndex() != lastDogLane)
        {
            // ���¹��ĵ�ǰ�ܵ�
            lastDogLane = dogMove.GetCurrentRoadIndex();
            // ���ü�ʱ��
            time = 0;
        }

        // ��ʱ�߼�
        if (time < delayTime)
        {
            // ����ʱ��
            time += Time.deltaTime;
        }
        else
        {
            // �������˵�Ŀ���ܵ�
            targetLane = dogMove.transform.position.y;
            // �ƶ����˵�Ŀ���ܵ�
            MoveToLane(targetLane);
        }
    }

    private void MoveToLane(float lane)
    {
        Vector3 targetPosition = new Vector3(transform.position.x, lane, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * 5);
    }
}

