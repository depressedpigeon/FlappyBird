using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreTracker : MonoBehaviour
{
    void Start()
    {

    }

    public static int score = 0;

    void Update()
    {
   
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
