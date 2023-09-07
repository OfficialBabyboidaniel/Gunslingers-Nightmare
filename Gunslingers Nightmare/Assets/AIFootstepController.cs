using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AIFootstepController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player; // Reference to the player character
    public float maxDistance = 10f; // The maximum distance at which footsteps can be heard
    public AudioSource footstepAudioSource; // Reference to the AudioSource on the enemy

    public AudioMixer audioMixer;

    private void Update()
    {
        Vector3 directionToPlayer = player.position - transform.position;

        // Calculate the angle between the forward direction of the enemy and the direction to the player
        float angle = Vector3.SignedAngle(transform.forward, directionToPlayer, Vector3.up);

        // Normalize the angle to be between -180 and 180 degrees
        angle = Mathf.Clamp(angle, -180f, 180f);

        // Calculate the panStereo value based on the angle (adjust this based on your desired effect)
        float panStereo = angle / 180f;

        // Set the panStereo value to the AudioSource
        footstepAudioSource.panStereo = panStereo;

        // Calculate the volume based on the distance (closer = louder, farther = quieter)
        float volume = 100f - (directionToPlayer.magnitude / maxDistance);

        // Clamp the volume to be between 0 and 1
        
        audioMixer.SetFloat("Master", volume);

        // Set the volume of the enemy's footsteps
        footstepAudioSource.volume = volume;

        // Play the footstep sound if it's not already playing
        if (!footstepAudioSource.isPlaying)
        {
            footstepAudioSource.Play();
        }
    }
}
