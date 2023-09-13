using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioClip DeathClip;

    public AudioSource audioSource;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Bullet"))
        {
            // Play the sound effect
            audioSource.PlayOneShot(DeathClip);

            // Disable the renderer to make the enemy invisible
            Renderer renderer = GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.enabled = false;
            }

            // Optionally, you can disable other components like Collider
            // Collider2D collider = GetComponent<Collider2D>();
            // if (collider != null)
            // {
            //     collider.enabled = false;
            // }

            // Destroy the GameObject after a delay or when the sound effect finishes playing
            Destroy(gameObject, DeathClip.length);
        }
    }


}
