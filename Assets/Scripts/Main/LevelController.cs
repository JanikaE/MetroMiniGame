using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    [Header("��Ϸ�ؿ���ť")]
    [SerializeField] private Button flyingBirt;

    private void Start()
    {
        flyingBirt.onClick.AddListener(() =>
        {
            SceneManager.LoadScene((int)SceneName.FlyingBirt);
        });
    }



}
