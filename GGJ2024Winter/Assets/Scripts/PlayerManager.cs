using UnityEngine;

public class PlayerManager : PersistentSingleton<PlayerManager>
{
    [SerializeField] public bool isWin { get; private set; }
    public void SetIsWin(bool b)
    {
        isWin = b;
    }
}
