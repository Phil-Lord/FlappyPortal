using UnityEngine;

public class Environment : MonoBehaviour
{
    public GameObject wallPrefab;
    public GameObject wallParent;
    GameObject wall;
    public GameObject ground;
    public GameObject background;
    float groundOffset;
    public float interval;
    public float speed;
    float spawnTime;

    private void Start()
    {
        // Spawn first wall
        wall = Instantiate(wallPrefab);
        wall.transform.parent = wallParent.transform;
        wall.GetComponent<Wall>().speed = speed;
    }

    void Update()
    {
        // Spawn wall every interval
        if (Time.time - spawnTime >= interval)
        {
            wall = Instantiate(wallPrefab);
            wall.transform.parent = wallParent.transform;
            wall.GetComponent<Wall>().speed = speed;
            spawnTime = Time.time;
        }

        // Move ground and background texture
        groundOffset += speed * Time.deltaTime;
        float offset = (100 * groundOffset) / ground.GetComponent<Renderer>().material.GetTexture("_MainTex").width;
        ground.GetComponent<Renderer>().material.mainTextureOffset = new Vector2(offset, 0);
        background.GetComponent<Renderer>().material.mainTextureOffset = new Vector2(offset * speed / 2, 0);
    }
}