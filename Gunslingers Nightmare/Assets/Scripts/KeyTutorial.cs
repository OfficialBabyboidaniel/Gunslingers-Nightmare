using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyTutorial : MonoBehaviour
{

   private GameObject ladder;
    private Ladder ladderScript;

    [SerializeField] private GameObject player;
    [SerializeField] private AudioClip pickUpSound;
    [SerializeField] private AudioClip delayedSound; // Add the delayed sound effect here.
    [SerializeField] private float delayBeforeDelayedSound = 2.0f; // Delay before playing the delayed sound.

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
        if (col.gameObject.CompareTag("Player"))
        {
            // Play the pickup sound.
            source.PlayOneShot(pickUpSound);

            // Set the keyFound variable in the ladder script.
            ladderScript.keyFound = true;

            // Destroy the key object.
            Destroy(gameObject);

            // Delay and then play the delayed sound.
            StartCoroutine(PlayDelayedSound());
        }
    }

    private System.Collections.IEnumerator PlayDelayedSound()
    {
        // Wait for the specified delay.
        yield return new WaitForSeconds(delayBeforeDelayedSound);

        // Create a new AudioSource for the delayed sound.
        AudioSource delayedAudioSource = player.AddComponent<AudioSource>();

        // Set the delayed sound clip and play it.
        delayedAudioSource.clip = delayedSound;
        delayedAudioSource.Play();

        // Optionally, you can destroy the delayed AudioSource component when the sound is done playing.
        Destroy(delayedAudioSource, delayedSound.length);
    }
}