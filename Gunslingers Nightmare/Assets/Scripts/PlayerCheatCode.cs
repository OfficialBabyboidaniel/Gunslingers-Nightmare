using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerCheatCode : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            // Restart the current level (scene)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            // Load scene 1
            SceneManager.LoadScene(0);
        }

        // Check if the "2" key is pressed
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            // Load scene 2
            SceneManager.LoadScene(1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            // Load scene 3
            SceneManager.LoadScene(2);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            // Load scene 4
            SceneManager.LoadScene(3);
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            // Load scene 5
            SceneManager.LoadScene(4);
        }



    }
}
