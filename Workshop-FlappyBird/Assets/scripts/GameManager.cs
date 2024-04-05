using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	private bool gameStarted = false;
	public static int currentScene = 1;
// private SceneManager sceneManager;
	// Start is called before the first frame update
	void Start()
	{
  //  sceneManager = gameObject.GetComponent<SceneManager>();
	}


	public static int score = 0; // Static var to hold the score

	// Update is called once per frame
	void Update()
	{
		if (currentScene == 1)
		{
			gameStarted = true;
			//scoreText.text = "Score: " + score;

		}
	}

	public void EndGame()
	{
		Debug.Log("Game Over");
		SceneManager.LoadScene(2);
	}

}