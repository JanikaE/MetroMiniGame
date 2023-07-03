using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    public static GameOverUI Instance;

    [SerializeField] private Transform gameVictoryPanel;
    [SerializeField] private Transform gameDefeatPanel;

    public SceneName CurrentSceneName { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
    /// <summary>
    /// 游戏结束时调用，显示游戏通关或游戏失败的面板
    /// </summary>
    /// <param name="sceneName">当前游戏场景的名字/param>
    /// <param name="isVictory">游戏是否通关</param>
    public void GameOver(SceneName sceneName, bool isVictory)
    {
        CurrentSceneName = sceneName;
        if (isVictory)
        {
            gameVictoryPanel.gameObject.SetActive(true);
        }
        else
        {
            gameDefeatPanel.gameObject.SetActive(true);
        }
    }
}
