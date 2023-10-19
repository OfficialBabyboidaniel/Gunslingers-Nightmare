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
        
    }

    public override void StateUpdate()
    {
        Debug.Log(audioSource.isActiveAndEnabled);
        if (!hasPlayedDeathSound)
        {
            hasPlayedDeathSound = true;
            Debug.Log("playing death sound");
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
