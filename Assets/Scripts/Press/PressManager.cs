using Press;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PressManager : MonoBehaviour
{
    [SerializeField] private Button B0;
    [SerializeField] private Button B1;
    [SerializeField] private Button B2;
    [SerializeField] private Text T0;
    [SerializeField] private Text T1;
    [SerializeField] private Text T2;
    [SerializeField] private Text Tip;
    private PressBox Box = new();
    private Dictionary<int, Button> buttons = new Dictionary<int, Button>();
    private Dictionary<int, Text> texts = new Dictionary<int, Text>();
    private int timer;
    private bool isUpdate;

    void Start()
    {
        Box.Init();
        GameOverUI.Instance.Init(SceneName.Press);
        GamePausePanelUI.Instance.Init(SceneName.Press);

        buttons.Add(0, B0);
        buttons.Add(1, B1);
        buttons.Add(2, B2);
        texts.Add(0, T0);
        texts.Add(1, T1);
        texts.Add(2, T2);
        timer = 0;
        isUpdate = true;

        for (int i = 0; i < PressBox.rage; i++)
        {
            Button button = buttons.GetValueOrDefault(i);
            button.onClick.AddListener(() =>
            {
                int key = buttons.FirstOrDefault(q => q.Value == button).Key;
                if (Box.light[key])
                {
                    Box.SwitchLight();
                    timer = 0;
                    Box.cnt++;
                }
                else
                {
                    BanButtons();
                    isUpdate = false;
                    GameOverUI.Instance.GameOver(false);
                }
            });
        }
    }

    void Update()
    {
        timer++;
        if (timer == 100 && isUpdate)
        {
            Box.SwitchLight();
            timer = 0;
        }

        UpdateColor();
        if (Box.cnt == PressBox.tar)
        {
            GameOverUI.Instance.GameOver(true);
        }
        
        Tip.text = Box.GetTip();
    }

    private void UpdateColor()
    {
        for (int i = 0; i < PressBox.rage; i++)
        {
            Button button = buttons.GetValueOrDefault(i);
            Text text = texts.GetValueOrDefault(i);
            if (Box.light[i])
            {
                button.image.color = Color.green;
                text.text = "O2";
            }
            else
            {
                button.image.color = Color.red;
                text.text = "CO2";
            }
        }
    }

    private void BanButtons()
    {
        for (int i = 0; i < PressBox.rage; i++)
        {
            Button button = buttons.GetValueOrDefault(i);
            button.enabled = false;
        }
    }
}
