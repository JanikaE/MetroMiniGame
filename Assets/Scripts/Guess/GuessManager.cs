using Guess;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuessManager : MonoBehaviour
{
    GuessBox Box = new();
    [SerializeField] private InputField inputField;

    void Start()
    {
        Box.Init();
    }

    void Update()
    {
        if (inputField != null && Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            int inputNum = int.Parse(inputField.text);
            int result = Box.Compare(inputNum);
        }
    }
}
