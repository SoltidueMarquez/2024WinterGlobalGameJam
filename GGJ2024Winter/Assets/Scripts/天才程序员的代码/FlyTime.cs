using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyTime : MonoBehaviour
{
    public float delayTime = 3f;
    private float time = 0;
    private void Update()
    {
        if(ObjectManager.Instance.isUltimate)
        {
            time += Time.deltaTime;
            if(time > delayTime )
            {
                time = 0;
                ObjectManager.Instance.energyNum = 0;
                ObjectManager.Instance.isUltimate = false;
            }
        }
    }
}
