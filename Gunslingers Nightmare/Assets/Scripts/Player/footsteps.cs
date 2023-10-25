using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footsteps : MonoBehaviour
{

    [SerializeField] private List<AudioClip> clips = new List<AudioClip>();
    [SerializeField] private AudioSource source;

    private float FootstepTimer;
    private bool playNextClip;
    [SerializeField] private float buffer = 0.3f;

    [SerializeField] private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        playNextClip = true;
        source.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playNextClip) {
            footstepsFunction();
        }

        if (!playNextClip) {
            FootstepTimer += Time.deltaTime;
            if (FootstepTimer > source.clip.length + buffer)   // 0.5 is extra buffer time.
            {
                playNextClip = true;
                FootstepTimer = 0;
            }
        }

        if (rb.velocity.magnitude > 1.0f) {
            source.enabled = true;
        }
        else {
            source.enabled = false;
        }

    }

    private void footstepsFunction() {
        int randomIndex = Random.Range(0, clips.Count);
        AudioClip randomClip = clips[randomIndex];
        source.clip = randomClip;
        if (source.enabled) {
            source.Play();
        }
        playNextClip = false;
    }
}
