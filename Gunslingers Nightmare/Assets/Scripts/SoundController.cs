using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player; // Reference to the player character
    public float maxDistance = 10f; // The maximum distance at which footsteps can be heard
    public AudioSource footstepAudioSource; // Reference to the AudioSource on the enemy

    public bool isDead = false;
    private void Update()
    {
        // Calculate the distance between the enemy and the player
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Calculate the volume based on the distance (closer = louder, farther = quieter)
        float volume = 1f - (distanceToPlayer / maxDistance);

        // Clamp the volume to be between 0 and 1
        volume = Mathf.Clamp01(volume);

        // Set the volume of the enemy's footsteps
        footstepAudioSource.volume = volume;
        if (isDead)
        {
            footstepAudioSource.Stop();
        }
        else if (!footstepAudioSource.isPlaying)
        {

            footstepAudioSource.Play();
        }
    }
}