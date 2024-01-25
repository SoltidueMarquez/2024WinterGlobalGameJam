using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectManager : Singleton<ObjectManager>
{
    [Tooltip("骨头数量")] public int bonesNum;
    [Tooltip("最大能量")] public int maxEnergyNum;
    [SerializeField, Tooltip("能量条")] private Slider energyBar;
    [SerializeField, Tooltip("能量条状态")] private List<Sprite> avatars;
    [SerializeField, Tooltip("头像")] private Image avatar;
    public bool isUltimate = false;
    public int energyNum;
    public int obstacleNum;
    private void Start()
    {
        energyBar.onValueChanged.AddListener(delegate { FullEnergySpecialEffect(); });//增添能量值满的回调函数
    }
    private void Update()
    {
        energyBar.value = (float)energyNum / (float)maxEnergyNum;//更新能量条
    }
    private void FullEnergySpecialEffect()
    {
        switch (energyBar.value)
        {
            case < 0.25f:
                avatar.sprite = avatars[0];
                break;
            case < 0.5f:
                avatar.sprite = avatars[1];
                break;
            case < 0.75f:
                avatar.sprite = avatars[2];
                break;
            case 1f:
                avatar.sprite = avatars[3];
                isUltimate = true;
                break;
        }
    }
}
