using UnityEngine;

public class Environment : MonoBehaviour
{
    // Wall prefab, parent, and object
    public GameObject wallPrefab;
    public GameObject wallParent;
    GameObject wall;

    // Ground, background, and ground offset
    public GameObject ground;
    public GameObject background;
    float groundOffset;

    // Game controller object for speed and interval
    public GameObject game;

    // Time when previous wall was spawned
    float spawnTime;

    private void Start()
    {
        // Spawn first wall
        wall = Instantiate(wallPrefab);
        wall.transform.parent = wallParent.transform;
        wall.GetComponent<Wall>().game = game;
    }

    void Update()
    {
        float gameSpeed = game.GetComponent<Game>().speed;

        // Spawn wall every interval
        if (Time.time - spawnTime >= game.GetComponent<Game>().interval)
        {
            wall = Instantiate(wallPrefab);
            wall.transform.parent = wallParent.transform;
            wall.GetComponent<Wall>().game = game;
            spawnTime = Time.time;
        }

        // Move ground and background texture
        groundOffset += gameSpeed * Time.deltaTime;
        float offset = (100 * groundOffset) / ground.GetComponent<Renderer>().material.GetTexture("_MainTex").width;
        ground.GetComponent<Renderer>().material.mainTextureOffset = new Vector2(offset, 0);
        background.GetComponent<Renderer>().material.mainTextureOffset = new Vector2(offset * gameSpeed / 2, 0);
    }
}