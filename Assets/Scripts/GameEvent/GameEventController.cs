using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEventController : MonoBehaviour
{
    [SerializeField] private Button leftButton;
    [SerializeField] private Button rightButton;
    [SerializeField] private Button mainScene;

    [SerializeField] private Transform description;
    [SerializeField] private Transform buttonContainer;
    [SerializeField] private Transform eventResult;
    [SerializeField] private Transform leftButtonResult;
    [SerializeField] private Transform rightButtonResult;

    private void Start()
    {
        leftButton.onClick.AddListener(() =>
        {
            Hide();
            leftButtonResult.gameObject.SetActive(true);
        });
        rightButton.onClick.AddListener(() =>
        {
            Hide();
            rightButtonResult.gameObject.SetActive(true);
        });
        mainScene.onClick.AddListener(() =>
        {
            MainController.Instance.GameOver(SceneName.Event01, true);
        });
    }




    private void Hide()
    {
        description.gameObject.SetActive(false);
        buttonContainer.gameObject.SetActive(false);
        eventResult.gameObject.SetActive(true);
    }

}
