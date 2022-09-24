using UnityEngine;

/// <summary>
/// Ground class for moving ground objects (unused).
/// This was the method tried before texture offsets.
/// </summary>
public class Ground : MonoBehaviour
{
    public float speed;
    public bool firstGround = false;
    //float timeOnScreen;
    //float spawnTime;
    void Start()
    {
        // Spawn at the bottom of the screen
        gameObject.transform.position = new Vector3(firstGround ? 0 : 17.78f, -2.635f, 0);

        // Calculate time taken for ground to travel across the screen
        //timeOnScreen = (Screen.width / speed) / 100;
        //timeOnScreen *= firstGround ? 1 : 2;
    }

    void Update()
    {
        Vector3 offset = new Vector3(Time.time * speed, -2.635f, 0);
        gameObject.GetComponent<SpriteRenderer>().material.mainTextureOffset = offset;

        // Move ground left, then reset if it leaves the screen
        /*if (gameObject.transform.position.x >= -17.77f)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.left * speed;
        }
        else
        {
            gameObject.transform.position = new Vector3(17.78f, -2.635f, 0);
        }*/

        // Time based
        /*
        if (Time.time - spawnTime >= timeOnScreen)
        {
            gameObject.transform.position = new Vector3(17.78f, -2.635f, 0);
            spawnTime = Time.time;
            timeOnScreen *= firstGround ? 2 : 1;
        }
        else
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.left * speed;
        }*/
    }
    /*
    private void OnBecameInvisible()
    {
        gameObject.transform.position = new Vector3(17.775f, -2.635f, 0);
    }*/
}