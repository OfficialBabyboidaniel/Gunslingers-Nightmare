using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{

    private GameObject ladder;
    private Ladder ladderScript;

    // Start is called before the first frame update
    void Start()
    {
        ladder = GameObject.Find("Ladder");
        ladderScript = ladder.GetComponent<Ladder>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player")) {
            Debug.Log("Key");
            ladderScript.keyFound = true;
            Destroy(gameObject);
        }
    }
}
