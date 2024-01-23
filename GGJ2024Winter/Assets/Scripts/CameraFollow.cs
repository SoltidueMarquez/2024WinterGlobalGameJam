using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothing;

    public Text position;
    //定义两个位置进行限制相机移动
    public Vector2 minPosition;
    public Vector2 maxPosition;
    // Start is called before the first frame update
    void Start()
    {
    
    }
    void Update()
    {
    
    }
    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 targetPos = target.position;
            targetPos.x = Mathf.Clamp(targetPos.x, minPosition.x, maxPosition.x);
            targetPos.y = Mathf.Clamp(targetPos.y, minPosition.y, maxPosition.y);
            targetPos.z = -10f;
            transform.position = Vector3.Lerp(transform.position, targetPos, smoothing);
        }

        position.text = $"{target.position.y * 100:00}m";
    }
}
