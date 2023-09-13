using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ladder : MonoBehaviour
{

    public bool keyFound;

    // Start is called before the first frame update
    void Start()
    {
        keyFound = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player") && keyFound) {
            Debug.Log("Ladder");
            SceneManager.LoadScene("Level1");
        }
    }
}
