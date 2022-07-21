using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public bool isAlive = true;
    public int score;
    public int highScore = 0;
    public GameObject txtScore;
    Rigidbody2D playerRigidBody;

    void Start()
    {
        playerRigidBody = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Jump when space is pressed
        if (isAlive && Input.GetKeyDown(KeyCode.Space))
        {
            playerRigidBody.velocity = Vector2.up * 6.5f;
            playerRigidBody.angularVelocity += 50;
        }

        if (playerRigidBody.velocity.y < 0)
        {
            playerRigidBody.angularVelocity -= 0.7f;
        }

        if (gameObject.transform.eulerAngles.z >= 45 && gameObject.transform.eulerAngles.z <= 315)
        {
            float angVel = playerRigidBody.angularVelocity;
            playerRigidBody.angularVelocity = 0;
            playerRigidBody.angularVelocity = -(angVel * 0.5f);
            //gameObject.transform.eulerAngles.Set(gameObject.transform.eulerAngles.z < 180 ? 45 : 315, 0, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Increment points after passing wall
        if (isAlive)
        {
            score++;
            txtScore.GetComponent<Text>().text = score.ToString();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Kill player on collision with a wall
        isAlive = false;
        txtScore.GetComponent<Text>().text = "0";
        
        if (score > highScore)
        {
            highScore = score;
        }
    }
}
