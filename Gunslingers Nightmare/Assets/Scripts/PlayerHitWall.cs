using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitWall : MonoBehaviour
{

    // [SerializeField] private AudioSource source;

    [SerializeField] private GameObject soundObject;
    private AudioSource source;
    [SerializeField] private AudioClip hitClip;

    // private Rigidbody2D rb;

    void Start() {
        source = soundObject.GetComponent<AudioSource>();
        // rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Wall")) {
            source.PlayOneShot(hitClip);
        }
    }

    /*
    void OnCollisionStay2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Wall") && rb.velocity.magnitude > 1.0f && playNextClip) {
            source.PlayOneShot(hitClip);
        }
    }
    */
}
