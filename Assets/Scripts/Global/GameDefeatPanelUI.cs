using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameDefeatPanelUI : MonoBehaviour
{
    [SerializeField] private Button mainScene;
    [SerializeField] private Button playAgain;

    private void Start()
    {
        mainScene.onClick.AddListener(() =>
        {
            MainController.Instance.GameOver(GameOverUI.Instance.CurrentSceneName, false);
        });
        playAgain.onClick.AddListener(() =>
        {
            SceneManager.LoadScene((int)SceneName.FlyingBirt);
        });
    }
}
