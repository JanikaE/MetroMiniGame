using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private Button startGameButton;
    [SerializeField] private Button quitGameButton;
    [SerializeField] private Button settingButton;
    [SerializeField] private Button aboutButton;

    private void Start()
    {
        startGameButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene((int)SceneName.Main);
        });
        quitGameButton.onClick.AddListener(() =>
        {
            Application.Quit();
        });
    }
}
