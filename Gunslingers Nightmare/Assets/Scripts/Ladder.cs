using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ladder : MonoBehaviour
{

    public bool keyFound;
    private AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        keyFound = false;
        source = gameObject.GetComponent<AudioSource>();
        source.mute = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (keyFound) {
            source.mute = false;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player") && keyFound) {
            Debug.Log("Ladder");
            SceneManager.LoadScene("Level1");
        }
    }
}
