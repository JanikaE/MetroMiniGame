using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEntry : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this);

        SceneManager.LoadScene((int)SceneName.Menu);
    }

    [RuntimeInitializeOnLoadMethod]
    public static void OnGameLoaded()
    {
        if (SceneManager.GetActiveScene().name == "GameEntry") return;

        SceneManager.LoadScene((int)SceneName.GameEntry);
    }
}
