using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioClip DeathClip;

    public AudioSource audioSource;
    public Transform player; // Reference to the player character
    public float maxDistance = 30f; // The maximum distance at which footsteps can be heard
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log(col.gameObject.name);
        if (col.gameObject.CompareTag("Bullet"))
        {
            // Play the sound effect
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            // Calculate the volume based on the distance (closer = louder, farther = quieter)
            float volume = 1f - (distanceToPlayer / maxDistance);

            // Clamp the volume to be between 0 and 1
            volume = Mathf.Clamp(volume, 0, 0.3f);

            // Set the volume of the enemy's footsteps
            audioSource.volume = volume;

            // You can also play the footstep sound here if it's not already playing
            audioSource.PlayOneShot(DeathClip);

            // Disable the renderer to make the enemy invisible
            Renderer renderer = GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.enabled = false;
            }
            AIChase movementScript = GetComponent<AIChase>();
            if (movementScript != null)
            {
                movementScript.CanMove = false;
                
            }

            SoundController footsteps = GetComponent<SoundController>();
            if (footsteps != null)
            {
                footsteps.isDead = true;
            }

            // Optionally, you can disable other components like Collider
            // Collider2D collider = GetComponent<Collider2D>();
            // if (collider != null)
            // {
            //     collider.enabled = false;
            // }

            // Destroy the GameObject after a delay or when the sound effect finishes playing
            Destroy(gameObject, DeathClip.length);
        }
    }


}
