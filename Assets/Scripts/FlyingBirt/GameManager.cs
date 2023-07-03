using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
        GameOverUI.Instance.Init(SceneName.FlyingBirt);
        GamePausePanelUI.Instance.Init(SceneName.FlyingBirt);
    }

    private void Update()
    {
        // 游戏通关
        if (Input.GetKeyDown(KeyCode.V))
        {
            // 显示游戏通关UI面板
            GameOverUI.Instance.GameOver(true);
            return;
        }

        // 游戏失败
        if (Input.GetKeyDown(KeyCode.F))
        {
            // 显示游戏失败UI面板
            GameOverUI.Instance.GameOver(false);
            return;
        }
    }
}
