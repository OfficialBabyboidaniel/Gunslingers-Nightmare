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

        if (Input.GetKeyDown(KeyCode.H))
        {
            // Load scene 0 (assuming your scenes start from 0)
            SceneManager.LoadScene(0);
        }

        // Check if the "2" key is pressed
        if (Input.GetKeyDown(KeyCode.J))
        {
            // Load scene 1 (assuming your scenes start from 0)
            SceneManager.LoadScene(1);
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            // Load scene 1 (assuming your scenes start from 0)
            SceneManager.LoadScene(2);
        }

    }
}
