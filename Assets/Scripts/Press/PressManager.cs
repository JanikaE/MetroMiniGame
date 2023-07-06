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
    [SerializeField] private Text Tip;
    private PressBox Box = new();
    private Dictionary<int, Button> buttons = new Dictionary<int, Button>();

    // Start is called before the first frame update
    void Start()
    {
        Box.Init();
        GameOverUI.Instance.Init(SceneName.Press);
        GamePausePanelUI.Instance.Init(SceneName.Press);

        buttons.Add(0, B0);
        buttons.Add(1, B1);
        buttons.Add(2, B2);

        for (int i = 0; i < PressBox.rage; i++)
        {
            Button button = buttons.GetValueOrDefault(i);
            button.onClick.AddListener(() =>
            {
                int key = buttons.FirstOrDefault(q => q.Value == button).Key;
                if (Box.light[key])
                {
                    Box.SwitchLight();
                    Box.cnt++;
                }
                else
                {
                    GameOverUI.Instance.GameOver(false);
                }
            });
        }
    }

    // Update is called once per frame
    void Update()
    {
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
            if (Box.light[i])
            {
                button.image.color = Color.green;
            }
            else
            {
                button.image.color = Color.red;
            }
        }
    }
}
