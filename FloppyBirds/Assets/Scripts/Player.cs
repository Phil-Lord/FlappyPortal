using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public bool isAlive = true;
    public int score;
    public int highScore = 0;
    public GameObject txtScore;
    Rigidbody2D playerRigidBody;
    public GameObject AudioController;

    void Start()
    {
        playerRigidBody = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Jump when space is pressed
        if (isAlive && Input.GetKeyDown(KeyCode.Space))
        {
            AudioController.GetComponent<Sounds>().PlayBounce();
            playerRigidBody.velocity = Vector2.up * 6.5f;
        }

        transform.eulerAngles = new Vector3(0, 0, playerRigidBody.velocity.y * 0.75f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Increment points after passing wall
        if (isAlive)
        {
            AudioController.GetComponent<Sounds>().PlayPoint();
            score++;
            txtScore.GetComponent<Text>().text = score.ToString();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Kill player on collision with a wall or the ground
        if (isAlive)
        {
            AudioController.GetComponent<Sounds>().PlayDeath();
        }

        isAlive = false;
        txtScore.GetComponent<Text>().text = "0";
        
        if (score > highScore)
        {
            highScore = score;
        }
    }
}