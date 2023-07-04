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
        // ��Ϸͨ��
        if (Input.GetKeyDown(KeyCode.V))
        {
            // ��ʾ��Ϸͨ��UI���
            GameOverUI.Instance.GameOver(true);
            return;
        }

        // ��Ϸʧ��
        if (Input.GetKeyDown(KeyCode.F))
        {
            // ��ʾ��Ϸʧ��UI���
            GameOverUI.Instance.GameOver(false);
            return;
        }
    }
}
