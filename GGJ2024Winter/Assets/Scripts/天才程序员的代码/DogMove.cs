using UnityEngine;
enum directions { up, down, flyUp, flyDown };
public class DogMove : MonoBehaviour
{
    public GameObject[] roadNumberPosition;
    [SerializeField] private int currentRoadIndex = 1;
    public bool isJump = false;  
    public float jumpTime = 0.5f;
    private float time = 0;
    private int target = 1;
    private int flyRoadIndex = 4;
    void Update()
    {
        if (!ObjectManager.Instance.isUltimate)
        {
            transform.tag = "Dog";
            if (Input.GetKeyDown(KeyCode.W) && !isJump)
            {
                ChangeLane(directions.up);
            }
            if (Input.GetKeyDown(KeyCode.S) && !isJump)
            {
                ChangeLane(directions.down);
            }
            if (Input.GetKeyDown(KeyCode.Space)||this.gameObject.layer==6)
            {
                Debug.Log("ÌøÔ¾");
                isJump = true;
                this.gameObject.layer = 6;
                time += Time.deltaTime;
                if(time > jumpTime)
                {
                    time = 0;
                    isJump = false;
                    this.gameObject.layer = 0;
                }
            }
            MoveToTargetLane();
        }
        else
        {
            transform.tag = "Fly";
            if (Input.GetKeyDown(KeyCode.W) && !isJump)
            {
                ChangeLane(directions.flyUp);
            }
            if (Input.GetKeyDown(KeyCode.S) && !isJump)
            {
                ChangeLane(directions.flyDown);
            }
            MoveToTargetLane();
        }
    }
    private void ChangeLane(directions dir)
    {
        #region
        if (dir == directions.up && currentRoadIndex > 0)
        {
            currentRoadIndex--;
            flyRoadIndex--;
            target = currentRoadIndex;
        }
        else if (dir == directions.down && currentRoadIndex < roadNumberPosition.Length / 2 - 1)
        {
            currentRoadIndex++;
            flyRoadIndex++;
            target = currentRoadIndex;
        }
        #endregion
        else if (dir == directions.flyUp && currentRoadIndex > 0)
        {
            currentRoadIndex--;
            flyRoadIndex--;
            target = flyRoadIndex;
        }
        else if (dir == directions.flyDown && flyRoadIndex < roadNumberPosition.Length - 1)
        {
            currentRoadIndex++;
            flyRoadIndex++;
            target = flyRoadIndex;
        }

    }
    private void MoveToTargetLane()
    {
        Vector3 targetPosition = new Vector3(transform.position.x, roadNumberPosition[target].transform.position.y, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * 10);
    }
    public int GetCurrentRoadIndex()
    {
        return currentRoadIndex;
    }
    public float GetCurrentRoadPosition()
    {
        return roadNumberPosition[target].transform.position.y;
    }
}
