using DG.Tweening;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;

[Serializable]
public class Evaluate
{
    public int obstacleNum;
    public String evaluation;
    public Sprite evaluateSprite;
}
public class UIManager : MonoBehaviour
{
    [Header("暂停界面")]
    [SerializeField, Tooltip("设置界面")] private GameObject settingMenu;
    [SerializeField, Tooltip("场景名")] private String sceneName;
    [SerializeField, Tooltip("暂停按钮")] private Button continueButton;
    [SerializeField, Tooltip("重新开始按钮")] private Button restartButton;
    [SerializeField, Tooltip("退出按钮")] private Button quitButton;

    [Header("游戏结束界面")]
    [SerializeField, Tooltip("评级")] private List<Evaluate> levels;
    [SerializeField, Tooltip("结束界面")] private GameObject endMenu;
    [SerializeField, Tooltip("评价图")] private Image evaluateImage;
    [SerializeField, Tooltip("结束文本")] private Text evaluateText;
    [SerializeField, Tooltip("结局文本")] private Text resultText;
    [SerializeField, Tooltip("骨头文本")] private Text bonesText;
    [SerializeField, Tooltip("重新开始文本")] private Text restartText;
    [SerializeField, Tooltip("重新开始按钮")] private Button restartButton2;
    private String result;
    public static UIManager Instance;

    [Header("游戏相关")]
    [SerializeField, Tooltip("重新开始文本")] private Text boneText;
    private void Update()
    {
        boneText.text=$"Bones:{ObjectManager.Instance.bonesNum}";
    }
    public void GameOver()
    {
        RoadManager.Instance.speed = 0;
        int index = 0;
        for (int i = 0; i < levels.Count; i++)
        {
            if (ObjectManager.Instance.obstacleNum >= levels[i].obstacleNum)
            {
                index = i;
            }
        }
        result = levels[index].evaluation;
        evaluateImage.sprite = levels[index].evaluateSprite;
        endMenu.SetActive(true);
        bonesText.DOText($"收集了{ObjectManager.Instance.bonesNum}个骨头", 1).SetEase(Ease.Linear).OnComplete(() =>
        {
            evaluateText.DOText($"这次一共突破了{ObjectManager.Instance.obstacleNum}个障碍，", 2).SetEase(Ease.Linear).OnComplete(
                () =>
                {
                    resultText.DOText(result, 2).SetEase(Ease.Linear).OnComplete(() =>
                    {
                        evaluateImage.DOFade(1, 3).OnComplete(() =>
                        {
                            restartButton2.interactable = true;
                            restartText.DOText("press anywhere to restart", 1).SetEase(Ease.Linear);
                        });
                    });
                });
        });
    }

    private void Awake()
    {
        Instance = this;
        continueButton.onClick.AddListener(PauseOrContinue);
        restartButton.onClick.AddListener(Restart);
        quitButton.onClick.AddListener(Quit);

        restartButton2.onClick.AddListener(Restart);
        restartButton2.interactable = false;
    }
    public void PauseOrContinue()
    {
        Time.timeScale = (Time.timeScale == 0) ? 1 : 0;
        settingMenu.SetActive(!settingMenu.activeSelf);
    }

    private void Restart()
    {
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1;
    }

    private void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    }
}
