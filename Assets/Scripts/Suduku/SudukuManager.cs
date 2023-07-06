using Suduku;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SudukuManager : MonoBehaviour
{
    #region Button和Text的定义
    [SerializeField] private Button B00;
    [SerializeField] private Button B01;
    [SerializeField] private Button B02;
    [SerializeField] private Button B03;
    [SerializeField] private Button B10;
    [SerializeField] private Button B11;
    [SerializeField] private Button B12;
    [SerializeField] private Button B13;
    [SerializeField] private Button B20;
    [SerializeField] private Button B21;
    [SerializeField] private Button B22;
    [SerializeField] private Button B23;
    [SerializeField] private Button B30;
    [SerializeField] private Button B31;
    [SerializeField] private Button B32;
    [SerializeField] private Button B33;
    [SerializeField] private Text T00;
    [SerializeField] private Text T01;
    [SerializeField] private Text T02;
    [SerializeField] private Text T03;
    [SerializeField] private Text T10;
    [SerializeField] private Text T11;
    [SerializeField] private Text T12;
    [SerializeField] private Text T13;
    [SerializeField] private Text T20;
    [SerializeField] private Text T21;
    [SerializeField] private Text T22;
    [SerializeField] private Text T23;
    [SerializeField] private Text T30;
    [SerializeField] private Text T31;
    [SerializeField] private Text T32;
    [SerializeField] private Text T33;
    #endregion

    private Dictionary<int, Button> Buttons = new Dictionary<int, Button>();
    private Dictionary<int, Text> Texts = new Dictionary<int, Text>();
    SudukuBox Box = new();

    void Start()
    {        
        Box.Init();
        GameOverUI.Instance.Init(SceneName.Suduku);
        GamePausePanelUI.Instance.Init(SceneName.Suduku);

        #region Buttons和Texts的初始化
        Buttons.Add(0, B00);
        Buttons.Add(1, B01);
        Buttons.Add(2, B02);
        Buttons.Add(3, B03);
        Buttons.Add(4, B10);
        Buttons.Add(5, B11);
        Buttons.Add(6, B12);
        Buttons.Add(7, B13);
        Buttons.Add(8, B20);
        Buttons.Add(9, B21);
        Buttons.Add(10, B22);
        Buttons.Add(11, B23);
        Buttons.Add(12, B30);
        Buttons.Add(13, B31);
        Buttons.Add(14, B32);
        Buttons.Add(15, B33);
        Texts.Add(0, T00);
        Texts.Add(1, T01);
        Texts.Add(2, T02);
        Texts.Add(3, T03);
        Texts.Add(4, T10);
        Texts.Add(5, T11);
        Texts.Add(6, T12);
        Texts.Add(7, T13);
        Texts.Add(8, T20);
        Texts.Add(9, T21);
        Texts.Add(10, T22);
        Texts.Add(11, T23);
        Texts.Add(12, T30);
        Texts.Add(13, T31);
        Texts.Add(14, T32);
        Texts.Add(15, T33);
        #endregion

        for (int i = 0; i < Buttons.Count; i++)
        {
            Button button = Buttons.GetValueOrDefault(i);
            
            if (Box.IsBlank(i))
            {
                button.onClick.AddListener(() =>
                {
                    Box.SetChoose(i);
                });
            }
            else
            {
                button.enabled = false;
            }
        }
    }

    void Update()
    {
        for (int i = 0; i < Texts.Count; i++)
        {
            Text text = Texts[i];
            int num = Box.GetValue(i);
            if (num == 0)
            {
                text.text = "";
            }
            else
            {
                text.text = num.ToString();
                if (Box.Check(i))
                {
                    text.color = Color.black;
                }
                else
                {
                    text.color = Color.red;
                }
            }
        }

        // 判定胜利
        if (Box.CheckVictory() == true)
        {
            GameOverUI.Instance.GameOver(true);
            return;
        }

        // 小键盘输入数字
        if (Box.isBlank[Box.ChooseX, Box.ChooseY])
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Box.playMap[Box.ChooseX, Box.ChooseY] = 0;
            }
            if (Input.GetKeyDown(KeyCode.Keypad1))
            {
                Box.playMap[Box.ChooseX, Box.ChooseY] = 1;
            }
            if (Input.GetKeyDown(KeyCode.Keypad2))
            {
                Box.playMap[Box.ChooseX, Box.ChooseY] = 2;
            }
            if (Input.GetKeyDown(KeyCode.Keypad3))
            {
                Box.playMap[Box.ChooseX, Box.ChooseY] = 3;
            }
            if (Input.GetKeyDown(KeyCode.Keypad4))
            {
                Box.playMap[Box.ChooseX, Box.ChooseY] = 4;
            }
            if (Input.GetKeyDown(KeyCode.Keypad5))
            {
                Box.playMap[Box.ChooseX, Box.ChooseY] = 5;
            }
            if (Input.GetKeyDown(KeyCode.Keypad6))
            {
                Box.playMap[Box.ChooseX, Box.ChooseY] = 6;
            }
            if (Input.GetKeyDown(KeyCode.Keypad7))
            {
                Box.playMap[Box.ChooseX, Box.ChooseY] = 7;
            }
            if (Input.GetKeyDown(KeyCode.Keypad8))
            {
                Box.playMap[Box.ChooseX, Box.ChooseY] = 8;
            }
            if (Input.GetKeyDown(KeyCode.Keypad9))
            {
                Box.playMap[Box.ChooseX, Box.ChooseY] = 9;
            }
        }
    }
}
