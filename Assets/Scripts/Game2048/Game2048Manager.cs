using Game2048;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Game2048Manager : MonoBehaviour
{
    [SerializeField] private Button Up;
    [SerializeField] private Button Down;
    [SerializeField] private Button Left;
    [SerializeField] private Button Right;
    [SerializeField] private Text N00;
    [SerializeField] private Text N01;
    [SerializeField] private Text N02;
    [SerializeField] private Text N10;
    [SerializeField] private Text N11;
    [SerializeField] private Text N12;
    [SerializeField] private Text N20;
    [SerializeField] private Text N21;
    [SerializeField] private Text N22;
    [SerializeField] private Text Score;
    [SerializeField] private Text Target;
    private Game2048Box Box;

    void Start()
    {
        Box = new Game2048Box();
        Box.Init();
        GameOverUI.Instance.Init(SceneName.Game2048);
        GamePausePanelUI.Instance.Init(SceneName.Game2048);

        // 用屏幕按钮游玩
        Up.onClick.AddListener(() =>
        {
            Box.Change((int)Game2048Box.Op.Up);
        });
        Down.onClick.AddListener(() =>
        {
            Box.Change((int)Game2048Box.Op.Down);
        });
        Left.onClick.AddListener(() =>
        {
            Box.Change((int)Game2048Box.Op.Left);
        });
        Right.onClick.AddListener(() =>
        {
            Box.Change((int)Game2048Box.Op.Right);
        });
    }

    void Update()
    {        
        N00.text = GetString(0, 0);
        N01.text = GetString(0, 1);
        N02.text = GetString(0, 2);
        N10.text = GetString(1, 0);
        N11.text = GetString(1, 1);
        N12.text = GetString(1, 2);
        N20.text = GetString(2, 0);
        N21.text = GetString(2, 1);
        N22.text = GetString(2, 2);
        Score.text = "Score:" + Box.score;
        Target.text = "Target:" + Game2048Box.target;
        
        // 用键盘按键游玩
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Box.Change((int)Game2048Box.Op.Up);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Box.Change((int)Game2048Box.Op.Down);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Box.Change((int)Game2048Box.Op.Left);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Box.Change((int)Game2048Box.Op.Right);
        }

        // 判定胜利失败
        if (Box.CheckVictory() == true)
        {
            GameOverUI.Instance.GameOver(true);
            return;
        }
        if (Box.CheckVictory() == false)
        {
            GameOverUI.Instance.GameOver(false);
            return;
        }
    }

    private string GetString(int i, int j)
    {
        if (Box.nums[i, j] == 0)
        {
            return "";
        }
        else
        {
            return Box.nums[i, j].ToString();
        }
    }
}
