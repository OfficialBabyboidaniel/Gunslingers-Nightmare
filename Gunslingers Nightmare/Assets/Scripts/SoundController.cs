using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player; // Reference to the player character
    public float maxDistance; // The maximum distance at which footsteps can be heard
    public AudioSource audioSource; // Reference to the AudioSource on the enemy

    public AudioClip audioClip;

    AIStats AIStats;

    public bool shouldPlay = true;


    // ändra så att de inte finns någon max range 

    public void Start()
    {
        if (gameObject.CompareTag("Enemy"))
        {
            AIStats = gameObject.GetComponent<AIStats>();
            maxDistance = AIStats.MaxSightRange;
        }
    }
    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (shouldPlay)
        {
            if (maxDistance >= distanceToPlayer)
            {
                audioSource.clip = audioClip;
                // Calculate the distance between the enemy and the player
                // Calculate the volume based on the distance (closer = louder, farther = quieter)

                //denna calcualtion måste kollas igenom
                float volume = 1f - (distanceToPlayer / maxDistance);

                // Clamp the volume to be between 0 and 1
                volume = Mathf.Clamp(volume, 0, 0.4f);



                // Set the volume of the enemy's footsteps
                audioSource.volume = volume;

                audioSource.Play();
            }
        }

    }
}