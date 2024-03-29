using UnityEngine;

public class Wall : MonoBehaviour
{
    // Game controller object for speed;
    public GameObject game;

    void Start()
    {
        // Spawn on the right side of the screen with random y
        gameObject.transform.position = new Vector3(10, Random.Range(2.5f, -2), 0);
    }

    void Update()
    {
        // Move wall left, then destroy if off the screen
        if (gameObject.transform.position.x > -10)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.left * game.GetComponent<Game>().speed;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}