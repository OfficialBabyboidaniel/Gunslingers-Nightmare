using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{

    private GameObject ladder;
    private Ladder ladderScript;

    // [SerializeField] private AudioSource source;

    [SerializeField] private GameObject player;
    [SerializeField] private AudioClip pickUpSound;

    private AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        ladder = GameObject.Find("Ladder");
        ladderScript = ladder.GetComponent<Ladder>();
        source = player.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player")) {
            // Debug.Log("Key");
            source.PlayOneShot(pickUpSound);
            ladderScript.keyFound = true;
            Destroy(gameObject);
        }
    }
}
