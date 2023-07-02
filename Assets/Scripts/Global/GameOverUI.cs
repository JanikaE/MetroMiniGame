using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private Transform gameVictoryPanel;
    [SerializeField] private Transform gameDefeatPanel;


    /// <summary>
    /// ��Ϸ����ʱ���ã���ʾ��Ϸͨ�ػ���Ϸʧ�ܵ����
    /// </summary>
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
