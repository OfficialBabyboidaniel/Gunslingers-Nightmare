using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDeath : State
{
    // Start is called before the first frame update

    public AudioClip DeathClip;

    public AudioSource audioSource;
    public Transform player; // Reference to the player character

    private bool hasPlayedDeathSound = false;

    public override void StateEnter()
    {
        // audioSource = AIManager.audioSource;
        // DeathClip = AIManager.Deathclip;
        //player = AIManager.player.transform;
        SoundController soundController = GetComponent<SoundController>();
        soundController.audioSource.Stop();
    }

    public override void StateUpdate()
    {
        if (!hasPlayedDeathSound)
        {
            hasPlayedDeathSound = true;
            Debug.Log("playing death sound");
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            // Calculate the volume based on the distance (closer = louder, farther = quieter)
            float volume = 1f - (distanceToPlayer / Mathf.Max(0.01f, distanceToPlayer)); // Avoid division by zero

            // Clamp the volume to be between 0 and 1
            volume = Mathf.Clamp01(volume);
            Debug.Log("death sound volume = " + volume);
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

            //borde inte behövas
            // AIChase movementScript = GetComponent<AIChase>();
            // if (movementScript != null)
            // {
            //     movementScript.CanMove = false;
            // }

            // SoundController footsteps = GetComponent<SoundController>();
            // if (footsteps != null)
            // {
            //     footsteps.isDead = true;
            // }

            // Optionally, you can disable other components like Collider
            Collider2D collider = GetComponent<Collider2D>();
            if (collider != null)
            {
                collider.enabled = false;
            }
            // Destroy the GameObject after a delay or when the sound effect finishes playing
            Destroy(gameObject, DeathClip.length);
        }
    }

    public override void StateExit()
    {

    }
}
