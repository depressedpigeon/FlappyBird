using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGameScene : MonoBehaviour
{

    public void Load(int sceneIndex) {
        SceneManager.LoadScene(sceneIndex);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Load the new scene
            Load(1);
        }

        // Check if left mouse button is clicked
        if (Input.GetMouseButtonDown(0)) // 0 corresponds to the left mouse button
        {
            // Load the new scene
            Load(1);
        }
        
    }
}

