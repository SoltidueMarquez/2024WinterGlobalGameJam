using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.CompareTag("Dog"))
        {
            UIManager.Instance.GameOver();
        }
        if (col.transform.CompareTag("Master"))
        {
            ObjectManager.Instance.energyNum = (ObjectManager.Instance.energyNum + 1
                <= ObjectManager.Instance.maxEnergyNum) ? ObjectManager.Instance.energyNum + 1 :
                ObjectManager.Instance.maxEnergyNum;
            ObjectManager.Instance.obstacleNum++;
            Destroy(gameObject);
        }
    }
}
