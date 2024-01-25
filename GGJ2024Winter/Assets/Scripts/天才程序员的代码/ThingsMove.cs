using UnityEngine;

public class MovePrefab : MonoBehaviour
{
    private bool hasBeenVisible = false;
    void Update()
    {
        transform.Translate(Vector3.left * RoadManager.Instance.speed * Time.deltaTime);
        if (IsVisibleFromCamera())
        {
            hasBeenVisible = true;
        }
        if (hasBeenVisible && !IsVisibleFromCamera())
        {
            Destroy(gameObject);
        }
    }
    private bool IsVisibleFromCamera()
    {
        var cam = Camera.main;
        var viewportPoint = cam.WorldToViewportPoint(transform.position);
        return viewportPoint.z > 0 && viewportPoint.x > 0 && viewportPoint.x < 1 && viewportPoint.y > 0 && viewportPoint.y < 1;
    }
}


