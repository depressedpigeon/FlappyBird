using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{

    public GameObject Obstacle;
    public int numberOfObjects;
    public int initialNumberOfObjects;


    public float spawnInterval = 4f; // Time between each obstacle spawn
    public float moveSpeed = 2f; // Speed at which obstacles move to the left
    public float destroyOffset = 2f; // Offset outside the visible part of the camera view to destroy obstacles

    public float offsetY = 3f;
    private float timer; // Timer for obstacle spawning

    // Start is called before the first frame update


    public void SpawnObstacle()
    {
        // Calculate a random height for the new obstacle
        float randomYPosition = Random.Range(-offsetY, offsetY);

        Vector3 tempPos = transform.position;
        tempPos.y += randomYPosition;

        Instantiate(Obstacle, tempPos, Quaternion.identity);
    }


    public void MoveObstacles()
    {

        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("ObstacleMain");
        foreach (GameObject obstacle in obstacles)
        {
            obstacle.transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);

            if (obstacle.transform.position.x < Camera.main.transform.position.x - Camera.main.orthographicSize * Camera.main.aspect - destroyOffset)
            {
                Destroy(obstacle);
            }
        }

    }

    void Start()
    {
        for (int i = 0; i < initialNumberOfObjects; i++)
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

