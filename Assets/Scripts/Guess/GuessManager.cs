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
    [SerializeField] private Text Cnt;
    [SerializeField] private Text Limit;
    [SerializeField] private Button Enter;
    private bool isEnter;

    void Start()
    {
        Box.Init();
        GameOverUI.Instance.Init(SceneName.Guess);
        GamePausePanelUI.Instance.Init(SceneName.Guess);

        Result.text = "";

        Enter.onClick.AddListener(() =>
        {
            isEnter = true;
        });
    }

    void Update()
    {
        if (inputField != null && isEnter)
        {
            int inputNum = int.Parse(inputField.text);
            string result = Box.Compare(inputNum);
            if (result == "0")
            {
                GameOverUI.Instance.GameOver(true);
            }
            else
            {
                Result.text = result;
            }

            inputField.text = "";
            isEnter = false;
            Box.cnt++;
            if (Box.cnt >= GuessBox.limit)
            {
                GameOverUI.Instance.GameOver(false);
            }
        }

        Cnt.text = "Guess Counts:" + Box.cnt;
        Limit.text = "Limit Counts:" + GuessBox.limit;
    }
}
