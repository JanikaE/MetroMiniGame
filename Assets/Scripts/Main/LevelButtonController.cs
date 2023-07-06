using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelButtonController : MonoBehaviour
{
    public static LevelButtonController Instance;

    private Button[] levelButtonList;

    private void Awake()
    {
        Instance = this;
        Init();
    }

    public void Init()
    {
        levelButtonList = GetComponentsInChildren<Button>();
        for (int i = 0; i < levelButtonList.Length; i++)
        {
            Button tempButton = levelButtonList[i];
            SceneName tempName = i + SceneName.FlappyBird;
            tempButton.onClick.AddListener(() =>
            {
                SceneManager.LoadScene((int)tempName);
            });
        }
    }

    public void LightUpPoint(List<SceneName> victoriousSceneList)
    {
        foreach (SceneName sceneName in victoriousSceneList)
        {
            levelButtonList[sceneName - SceneName.FlappyBird].GetComponent<Image>().color = Color.red;
        }

    }


}
