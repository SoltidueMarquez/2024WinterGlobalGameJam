using UnityEngine;

public class test : MonoBehaviour
{
    [Header("²ÎÊý")]
    [SerializeField] private bool x;
    private bool y;
    private void Start()
    {
        x = PlayerManager.Instance.isWin;
        PlayerManager.Instance.SetIsWin(y);
    }
}
