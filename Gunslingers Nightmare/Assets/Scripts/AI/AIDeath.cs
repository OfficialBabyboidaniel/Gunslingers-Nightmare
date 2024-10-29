using UnityEngine;

public class AIDeath : State
{
    // Public variables
    public AudioClip DeathClip; // Audio clip to play when the enemy dies
    public AudioSource audioSource; // Audio source to play the death clip
    public Transform player; // Reference to the player character

    // Private variables
    private bool hasPlayedDeathSound = false; // Flag to ensure the death sound is played only once

    // Called when the state is entered
    public override void StateEnter()
    {
        // Add any necessary initialization code here
    }

    // Called every frame while the state is active
    public override void StateUpdate()
    {
        // Check if the death sound has not been played yet
        if (!hasPlayedDeathSound)
        {
            hasPlayedDeathSound = true; // Set the flag to true to prevent multiple plays
            Debug.LogError("Enemy has died"); // Log the death event

            // Play the death sound
            audioSource.PlayOneShot(DeathClip);

            // Disable the renderer to make the enemy invisible
            Renderer renderer = GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.enabled = false;
            }

            // Disable the collider to prevent interactions
            Collider2D collider = GetComponent<Collider2D>();
            if (collider != null)
            {
                collider.enabled = false;
            }

            // Destroy the GameObject after the death sound finishes playing
            Destroy(gameObject, DeathClip.length);
        }
    }

    // Called when the state is exited
    public override void StateExit()
    {
        // Add any necessary cleanup code here
    }
}