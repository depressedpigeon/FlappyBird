using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTracker : MonoBehaviour
{
    void Start()
    {

    }

    Scene currentScene = SceneManager.getActiveScene();
    public static int score = 0;

    void Update()
    {
        if (currentScene = 1)
        {
            gameStarted = true;
            scoreText.text = "Score: " + score;
        }
    }

    private void IncreaseScore()
    {
        score++;
    }

    // ------add to the player logic
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("ScoreCollider"))
        {
            IncreaseScore();
        }
    }
}
