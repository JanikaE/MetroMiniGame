using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainController : MonoBehaviour
{
    public static MainController Instance;

    private SceneName finishedSceneName;
    private bool isVictory;

    private void Awake()
    {
        Instance = this;
    }


    public void GameOver(SceneName sceneName, bool isVictory)
    {
        finishedSceneName = sceneName;
        this.isVictory = isVictory;
        SceneManager.LoadScene((int)SceneName.Main);
        SceneManager.sceneLoaded += sceneLoadedCallback;

    }

    private void sceneLoadedCallback(Scene scene, LoadSceneMode loadSceneMode)
    {
        if (scene.name != "Main") return;
        if (isVictory)
        {
            switch (finishedSceneName)
            {
                case SceneName.FlyingBirt:
                    Debug.Log(SceneManager.GetActiveScene().name);
                    LevelButtonController.Instance.LightUpPoint(2);
                    break;
                default:
                    break;
            }
        }
    }
}
