using UnityEngine;
using System.Collections.Generic;

public class TutorialSoundManager : MonoBehaviour
{
    public List<AudioClip> soundsToPlay;
    public float initialDelay = 2.0f;        // Delay before playing the first audio clip.
    public float delayBetweenSounds = 2.0f; // Delay between playing subsequent audio clips.

    private AudioSource audioSource;
    private int currentIndex = 0;
    private bool canSkip = false; // Flag to allow skipping.

    private void Awake()
    {
        // Get the AudioSource component attached to the GameObject.
        audioSource = GetComponent<AudioSource>();

        // If there is no AudioSource component, add one.
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Hook up the event handler for when the audio source has finished playing.
        audioSource.loop = false; // Ensure looping is disabled.
        audioSource.playOnAwake = false;
        audioSource.volume = 1.0f;
        audioSource.pitch = 1.0f;
        audioSource.spatialBlend = 0.0f;
        audioSource.dopplerLevel = 0.0f;
        audioSource.rolloffMode = AudioRolloffMode.Logarithmic;
        audioSource.minDistance = 1.0f;
        audioSource.maxDistance = 500.0f;
        audioSource.spatialize = false;

        // Start playing sounds after the initial delay.
        Invoke("PlayNextSound", initialDelay);
    }

    private void Update()
    {
        // Check for space key press to skip to the next sound.
        if (canSkip && Input.GetKeyDown(KeyCode.Space))
        {
            SkipToNextSound();
        }
    }

    private void PlayNextSound()
    {
        if (currentIndex < soundsToPlay.Count)
        {
            // Set the current AudioClip to play.
            audioSource.clip = soundsToPlay[currentIndex];

            // Play the sound.
            audioSource.Play();

            // Allow skipping for the current sound.
            canSkip = true;

            // Increment the index for the next sound.
            currentIndex++;

            // Delay before playing the next sound based on the clip's length.
            float delay = audioSource.clip.length + delayBetweenSounds;
            Invoke("PlayNextSound", delay);
        }
        else
        {
            // All sounds have been played, disable the component.
            enabled = false;
        }
    }

    private void SkipToNextSound()
    {
        // Check if there's a sound playing.
        if (audioSource.isPlaying)
        {
            // Stop the current sound.
            audioSource.Stop();

            // Cancel the invoke for the next sound since we're skipping.
            CancelInvoke("PlayNextSound");

            // Delay before playing the next sound based on the specified delayBetweenSounds.
            float delay = delayBetweenSounds;
            Invoke("PlayNextSound", delay);

            // Disable skipping until the next sound starts.
            canSkip = false;
        }
    }
}