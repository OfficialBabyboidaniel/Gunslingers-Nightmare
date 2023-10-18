using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    // Start is called before the first frame update

    public int playerHP = 30;

    public AudioClip DeathClip;

    public AudioClip GameOver;

    public AudioSource audioSource;

    private bool isDead = false;

    public GameObject canvas;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (playerHP <= 0 && !isDead)
        {
            audioSource.PlayOneShot(DeathClip);
            Renderer renderer = GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.enabled = false;
            }

            Destroy(gameObject, DeathClip.length);

            PlayerPrefs.SetInt("PreviosScene", SceneManager.GetActiveScene().buildIndex);
            SceneManager.LoadScene(3);

            Time.timeScale = 0f;

            isDead = true;
        }
    }
}
