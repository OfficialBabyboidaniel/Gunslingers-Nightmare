using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    // Start is called before the first frame update

    public int playerHP = 30;

    public AudioClip DeathClip;

    public AudioSource audioSource;

    private bool isNotDead = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(playerHP);
        if (playerHP <= 0 && !isNotDead )
        {
            audioSource.PlayOneShot(DeathClip);
            Renderer renderer = GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.enabled = false;
            }

            Destroy(gameObject, DeathClip.length);

            Time.timeScale = 0f;
            
            isNotDead = true;
        }
    }
}
