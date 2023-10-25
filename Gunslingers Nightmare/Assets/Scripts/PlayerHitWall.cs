using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitWall : MonoBehaviour
{

    // [SerializeField] private AudioSource source;

    [SerializeField] private GameObject soundObject;
    private AudioSource source;
    [SerializeField] private AudioClip hitClip;

    [SerializeField] private float buffer = 0.3f;

    private Rigidbody2D rb;
    private bool playNextClip;
    private float wallTimer;

    public bool playSound = true;

    public bool playSoundContinues = true;


    void Start() {
        source = soundObject.GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        playNextClip = false;
    }

    void Update() {
        if (!playNextClip) {
            wallTimer += Time.deltaTime;
            if (wallTimer > source.clip.length + buffer)   // 0.5 is extra buffer time.
                {
                    playNextClip = true;
                    wallTimer = 0;
                }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Wall") && playSound) {
            source.PlayOneShot(hitClip);
        }
    }

    void OnCollisionStay2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Wall") && rb.velocity.magnitude > 1.0f && playNextClip && playSound && playSoundContinues) {
            source.PlayOneShot(hitClip);
            playNextClip = false;
        }
    }

}
