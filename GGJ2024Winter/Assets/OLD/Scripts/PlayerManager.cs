using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance { get; private set; }//单例模式调用
    [SerializeField] public bool isWin;

    private void Awake()
    {
        instance = this;
    }

    public void SetIsWin(bool b) { isWin = b; }
}
