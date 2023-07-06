using Guess;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuessManager : MonoBehaviour
{
    GuessBox Box = new();
    [SerializeField] private InputField inputField;
    [SerializeField] private Text Result;
    [SerializeField] private Text Range;
    [SerializeField] private Text Cnt;
    [SerializeField] private Text Limit;

    void Start()
    {
        Box.Init();
        GameOverUI.Instance.Init(SceneName.Guess);
        GamePausePanelUI.Instance.Init(SceneName.Guess);
    }

    void Update()
    {
        if (inputField != null && Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            int inputNum = int.Parse(inputField.text);
            int result = Box.Compare(inputNum);
            switch (result)
            {
                case 0:
                    GameOverUI.Instance.GameOver(true);
                    break;
                case 1:
                    Result.text = "Too Large";
                    break;
                case 2:
                    Result.text = "Too Small";
                    Range.text = Box.GetRange();
                    break;
            }
            inputField.text = "";
            Range.text = Box.GetRange();
            Box.cnt++;
            if (Box.cnt > GuessBox.limit)
            {
                GameOverUI.Instance.GameOver(false);
            }
        }

        Cnt.text = "Guess Counts:" + Box.cnt;
        Limit.text = "Limit Counts:" + GuessBox.limit;
    }
}
