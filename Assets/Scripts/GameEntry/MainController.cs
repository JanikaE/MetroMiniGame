using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainController : MonoBehaviour
{
    public static MainController Instance;

    private SceneName finishedSceneName;
    private bool isVictory;

    private List<SceneName> victoriousSceneList = new List<SceneName>();

    private void Awake()
    {
        Instance = this;
        SceneManager.sceneLoaded += sceneLoadedCallback;
    }


    public void GameOver(SceneName sceneName, bool isVictory)
    {
        finishedSceneName = sceneName;
        this.isVictory = isVictory;
        SceneManager.LoadScene((int)SceneName.Main);
    }

    private void sceneLoadedCallback(Scene scene, LoadSceneMode loadSceneMode)
    {
        if (scene.name != "Main") return;
        if (isVictory)
        {
            if (!victoriousSceneList.Contains(finishedSceneName))
            {
                victoriousSceneList.Add(finishedSceneName);
            }
        }
        LevelButtonController.Instance.LightUpPoint(victoriousSceneList);
        // 重置一下isVictory的值，防止bug
        isVictory = false;
    }
}
