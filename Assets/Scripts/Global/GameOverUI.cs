using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private Transform gameVictoryPanel;
    [SerializeField] private Transform gameDefeatPanel;


    /// <summary>
    /// 游戏结束时调用，显示游戏通关或游戏失败的面板
    /// </summary>
    /// <param name="isVictory">游戏是否通关</param>
    public void GameOver(bool isVictory)
    {
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
