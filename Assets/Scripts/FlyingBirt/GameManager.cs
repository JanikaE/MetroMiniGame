using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameOverUI gameOverUI;

    private void Update()
    {
        // ��Ϸͨ��
        if (Input.GetKeyDown(KeyCode.V))
        {
            // ��ʾ��Ϸͨ��UI���
            gameOverUI.GameOver(SceneName.FlyingBirt, true);
            return;
        }

        // ��Ϸʧ��
        if (Input.GetKeyDown(KeyCode.F))
        {
            // ��ʾ��Ϸʧ��UI���
            gameOverUI.GameOver(SceneName.FlyingBirt, false);
            return;
        }
    }
}
