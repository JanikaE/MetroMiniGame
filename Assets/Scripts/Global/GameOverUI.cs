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
    /// ��Ϸ����ʱ���ã���ʾ��Ϸͨ�ػ���Ϸʧ�ܵ����
    /// </summary>
    /// <param name="sceneName">��ǰ��Ϸ����������/param>
    /// <param name="isVictory">��Ϸ�Ƿ�ͨ��</param>
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
