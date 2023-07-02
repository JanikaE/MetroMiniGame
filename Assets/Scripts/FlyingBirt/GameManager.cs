using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameOverUI gameOverUI;

    private void Update()
    {
        // 游戏通关
        if (Input.GetKeyDown(KeyCode.V))
        {
            // 显示游戏通关UI面板
            gameOverUI.GameOver(true);
            return;
        }

        // 游戏失败
        if (Input.GetKeyDown(KeyCode.F))
        {
            // 显示游戏失败UI面板
            gameOverUI.GameOver(false);
            return;
        }
    }
}
