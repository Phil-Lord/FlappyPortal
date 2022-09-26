using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public GameObject companionCube;
    public GameObject walls;
    public GameObject mainMenuUI;
    public GameObject scoreUI;
    public GameObject gameOverUI;

    public float speed;
    public float interval;

    // Speed and interval sliders
    public Slider speedSlider;
    public Slider intervalSlider;
    public Text speedText;
    public Text intervalText;

    // Difficulty preset buttons
    public Button easyButton;
    public Button mediumButton;
    public Button hardButton;

    Player player;

    private void Start()
    {
        // Set default speed and interval
        speed = 8;
        speedSlider.value = 8;
        speedText.text = "8";
        interval = 1.5f;
        intervalSlider.value = 1.5f;
        intervalText.text = "1.5";

        // Hide player and all UI but main menu
        companionCube.SetActive(false);
        mainMenuUI.SetActive(true);
        mainMenuUI.transform.Find("MainMenuPanel").gameObject.SetActive(true);
        mainMenuUI.transform.Find("OptionsPanel").gameObject.SetActive(false);
        gameOverUI.SetActive(false);
        scoreUI.SetActive(false);

        // Set player
        player = companionCube.GetComponent<Player>();
    }

    private void Update()
    {
        // Check for player death
        if (!player.isAlive)
        {
            scoreUI.SetActive(false);
            gameOverUI.SetActive(true);

            gameOverUI.transform.Find("GameOverPanel").Find("txtScoreNum").GetComponent<Text>().text = player.score.ToString();
            gameOverUI.transform.Find("GameOverPanel").Find("txtHighScoreNum").GetComponent<Text>().text = player.highScore.ToString();
        }
    }

    public void RestartGame()
    {
        // Sort UI and show player
        mainMenuUI.SetActive(false);
        gameOverUI.SetActive(false);
        companionCube.SetActive(true);
        scoreUI.SetActive(true);

        // Reset player
        player.isAlive = true;
        player.score = 0;
        companionCube.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        companionCube.GetComponent<Rigidbody2D>().angularVelocity = 0;
        companionCube.transform.SetPositionAndRotation(new Vector3(-2.5f, 0, 0), new Quaternion(0, 0, 0, 0));

        // Delete walls
        foreach (Transform wall in walls.transform)
        {
            Destroy(wall.gameObject);
        }
    }

    public void ReturnToMainMenu()
    {
        player.isAlive = true;
        gameOverUI.SetActive(false);
        companionCube.SetActive(false);
        scoreUI.SetActive(false);
        mainMenuUI.SetActive(true);
        mainMenuUI.transform.Find("MainMenuPanel").gameObject.SetActive(true);
        mainMenuUI.transform.Find("OptionsPanel").gameObject.SetActive(false);
    }

    public void Options()
    {
        // Activate options and hide main menu
        mainMenuUI.transform.Find("MainMenuPanel").gameObject.SetActive(false);
        mainMenuUI.transform.Find("OptionsPanel").gameObject.SetActive(true);

        // Speed and interval slider event listeners
        speedSlider.onValueChanged.AddListener((s) =>
        {
            s = Mathf.Round(s);
            speedText.text = s.ToString();
            speed = s;
        });
        
        intervalSlider.onValueChanged.AddListener((i) =>
        {
            i -= i % .25f;
            intervalText.text = i.ToString("0.00");
            interval = i;
        });

        // Difficulty preset button event listeners
        easyButton.onClick.AddListener(() =>
        {
            speed = 5;
            speedSlider.value = 5;
            speedText.text = "5";

            interval = 2;
            intervalSlider.value = 2;
            intervalText.text = "2";
        });
        
        mediumButton.onClick.AddListener(() =>
        {
            speed = 8;
            speedSlider.value = 8;
            speedText.text = "8";

            interval = 1.5f;
            intervalSlider.value = 1.5f;
            intervalText.text = "1.5";
        });

        hardButton.onClick.AddListener(() =>
        {
            speed = 15;
            speedSlider.value = 15;
            speedText.text = "15";

            interval = 1;
            intervalSlider.value = 1;
            intervalText.text = "1";
        });
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}