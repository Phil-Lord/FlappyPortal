using UnityEngine;

public class SpawnWall : MonoBehaviour
{
    public GameObject wallPrefab;
    GameObject wall;
    public GameObject wallParent;
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
    }
}
