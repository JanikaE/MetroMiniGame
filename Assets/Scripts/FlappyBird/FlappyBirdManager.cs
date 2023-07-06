using UnityEngine;
using UnityEngine.UI;

public class FlappyBirdManager : MonoBehaviour
{
    public Player player;
    public Text scoreText;
    public Text targetScoreText;
    public GameObject playButton;

    [SerializeField] private int targetScore;

    private int score;

    private void Awake()
    {
        Application.targetFrameRate = 60;

        Pause();
    }

    private void Start()
    {
        GameOverUI.Instance.Init(SceneName.FlappyBird);
        GamePausePanelUI.Instance.Init(SceneName.FlappyBird);
        targetScoreText.text = "Ŀ�꣺" + targetScore;
        playButton.GetComponent<Button>().onClick.AddListener(() =>
        {
            Play();
        });
    }

    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();

        playButton.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;
        

        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for (int i = 0; i < pipes.Length; i++) {
            Destroy(pipes[i].gameObject);
        }

    }

    public void GameOver()
    {
        GameOverUI.Instance.GameOver(false);
        Pause();
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
        if (score >= targetScore)
        {
            GameOverUI.Instance.GameOver(true);
            Pause();
        }
    }

}
