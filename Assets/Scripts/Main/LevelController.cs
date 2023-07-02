using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    [Header("ÓÎÏ·¹Ø¿¨°´Å¥")]
    [SerializeField] private Button flyingBirt;

    private void Start()
    {
        flyingBirt.onClick.AddListener(() =>
        {
            SceneManager.LoadScene((int)SceneName.FlyingBirt);
        });
    }



}
