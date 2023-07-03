using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameVictoryPanelUI : MonoBehaviour
{
    [SerializeField] private Button mainScene;

    private void Start()
    {
        mainScene.onClick.AddListener(() =>
        {
            // 返回主场景，并通知主场景点亮关卡对应的点
            MainController.Instance.GameOver(GameOverUI.Instance.CurrentSceneName, true);
        });
    }
}
