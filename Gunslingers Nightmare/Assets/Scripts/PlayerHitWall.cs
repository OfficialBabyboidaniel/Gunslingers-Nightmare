using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitWall : MonoBehaviour
{

    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip clip;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Wall")) {
            source.PlayOneShot(clip);
        }
    }
}
