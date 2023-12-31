using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    // Start is called before the first frame update

    public int playerHP = 30;
    public AudioSource audioSource;
    public AudioClip DeathClip;
    private bool isDead = false;
    public float timeBetweenFiring = 0.3f;
    // Update is called once per frame

    void Update()
    {


        if (playerHP <= 0 && !isDead)
        {
            
            Debug.LogError("player is dead");
            audioSource.PlayOneShot(DeathClip);

            Renderer renderer = GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.enabled = false;
            }

            isDead = true;

            Invoke("LoadNextScene", DeathClip.length + 0.1f);
        }
    }

    void LoadNextScene()
    {
        PlayerPrefs.SetInt("PreviosScene", SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.Save();
        SceneManager.LoadScene(3);
    }
}
