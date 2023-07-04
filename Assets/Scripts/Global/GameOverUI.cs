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

    public void Init(SceneName currentSceneName)
    {
        CurrentSceneName = currentSceneName;
    }

    /// <summary>
    /// ��Ϸ����ʱ���ã���ʾ��Ϸͨ�ػ���Ϸʧ�ܵ����
    /// </summary>
    /// <param name="sceneName">��ǰ��Ϸ����������/param>
    /// <param name="isVictory">��Ϸ�Ƿ�ͨ��</param>
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
