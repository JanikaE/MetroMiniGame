using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePausePanelUI : MonoBehaviour
{
    public static GamePausePanelUI Instance;
    [SerializeField] private Transform container;
    [SerializeField] private Button mainScene;
    [SerializeField] private Button resetScene;

    private SceneName currentSceneName;

    private void Awake()
    {
        Instance = this;
    }

    public void Init(SceneName currentSceneName)
    {
        this.currentSceneName = currentSceneName;
    }

    private void Start()
    {
        mainScene.onClick.AddListener(() =>
        {
            MainController.Instance.GameOver(currentSceneName, false);
        });
        resetScene.onClick.AddListener(() =>
        {
            SceneManager.LoadScene((int)currentSceneName);
        });
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (container.gameObject.activeSelf)
            {
                container.gameObject.SetActive(false);
            }
            else
            {
                container.gameObject.SetActive(true);
            }
        }
    }

}
