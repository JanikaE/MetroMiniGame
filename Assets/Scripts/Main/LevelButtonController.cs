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
            Button temp = levelButtonList[i];
            temp.onClick.AddListener(() =>
            {
                SceneManager.LoadScene((int)SceneName.FlyingBirt);
            });
        }
    }

    public void LightUpPoint(int levelId)
    {
        switch (levelId)
        {
            case 2:
                levelButtonList[0].GetComponent<Image>().color = Color.red;
                break;
            default:
                break;
        }
    }


}
