using UnityEngine;

public class MasterMove : MonoBehaviour
{
    public DogMove dogMove;
    public float delayTime;
    public float[] lay;
    private BalanceController balanceController;
    private float time = 0;
    private int lastDogLane;
    private void Start()
    {
        balanceController=GetComponent<BalanceController>();
    }
    void Update()
    {
        if (dogMove.transform.tag == "Dog")
        {
            if (dogMove.GetCurrentRoadIndex() != lastDogLane)
            {
                lastDogLane = dogMove.GetCurrentRoadIndex();
                time = 0;
            }
            if (time < delayTime)
            {
                time += Time.deltaTime;
            }
            else
            {
                balanceController.rayLength = lay[lastDogLane];
            }
        }
        else if(dogMove.transform.tag=="Fly")
        {

            balanceController.rayLength = lay[3];
        }
    }
}

