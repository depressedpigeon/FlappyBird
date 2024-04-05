using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{

    public GameObject Obstacle;
    public int numberOfObjects;
    public int initialNumberOfObjects;

    public float spawnInterval = 2f; // Time between each obstacle spawn
    public float moveSpeed = 2f; // Speed at which obstacles move to the left
    public float destroyOffset = 2f; // Offset outside the visible part of the camera view to destroy obstacles

    private float timer; // Timer for obstacle spawning

    // Start is called before the first frame update


    public void SpawnObstacle()
    {
        // Instantiate the obstacle prefab
        GameObject newObstacle = Instantiate(Obstacle, transform.position, Quaternion.identity);

        // Move the obstacle to the left of the camera view
        newObstacle.transform.position = new Vector3(Camera.main.transform.position.x + Camera.main.orthographicSize * Camera.main.aspect + destroyOffset,
                                                      Random.Range(-2f, 2f), 0f);
    }


    public void MoveObstacles()
    {

        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("ObstacleMain");
        foreach (GameObject obstacle in obstacles)
        {
            obstacle.transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);

            if (obstacle.transform.position.x < Camera.main.transform.position.x - Camera.main.orthographicSize * Camera.main.aspect - destroyOffset)
            {
                // Destroy obstacle
                Destroy(obstacle);
            }
        }

    }

    void Start()
    {
        for (int i = 2; i < initialNumberOfObjects; i++)
        {
            SpawnObstacle();
        }
    }

    // Update is called once per frame
    void Update()
    {

        // Increment timer
        timer += Time.deltaTime;

        // If it's time to spawn a new obstacle
        if (timer >= spawnInterval)
        {
            SpawnObstacle();
            timer = 0f; // Reset timer
        }

        // Move existing obstacles to the left
        MoveObstacles();

    }
}

