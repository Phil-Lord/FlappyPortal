using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public GameObject companionCube;
    public GameObject walls;
    public GameObject scoreUI;
    public GameObject gameOverUI;

    Player player;

    private void Start()
    {
        // Hide UI and set player
        gameOverUI.SetActive(false);
        scoreUI.SetActive(true);
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
        // Sort UI
        gameOverUI.SetActive(false);
        scoreUI.SetActive(true);

        // Reset player
        player.isAlive = true;
        player.score = 0;
        companionCube.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        companionCube.GetComponent<Rigidbody2D>().angularVelocity = 0;
        companionCube.transform.position = new Vector3(-2.5f, 0, 0);
        companionCube.transform.rotation = new Quaternion(0, 0, 0, 0);

        // Delete walls
        foreach (Transform wall in walls.transform)
        {
            Destroy(wall.gameObject);
        }
    }
}