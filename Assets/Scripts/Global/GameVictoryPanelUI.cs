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
            // ��������������֪ͨ�����������ؿ���Ӧ�ĵ�
            MainController.Instance.GameOver(GameOverUI.Instance.CurrentSceneName, true);
        });
    }
}