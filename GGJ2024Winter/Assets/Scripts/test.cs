using UnityEngine;

public class test : MonoBehaviour
{
    [Header("����")]
    [SerializeField] private bool x;
    private bool y;
    private void Start()
    {
        x = PlayerManager.Instance.isWin;
        PlayerManager.Instance.SetIsWin(y);
    }
}
