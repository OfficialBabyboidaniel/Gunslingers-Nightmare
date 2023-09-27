using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIChase : MonoBehaviour
{
    public GameObject player;
    public float speed;
    private float distance;

    public float MaxSightRange = 10.0f;
    public bool CanMove = true;

    public int HitDamage = 4;

    public bool canAttack = true;
    public float attackCooldown = 3f; // Cooldown time in seconds
    public float timeSinceLastAttack = 0f;

    public float hitRange = 1.0f;

    public AudioSource AudioSource;

    public AudioClip audioClip;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance <= MaxSightRange)
        {
            if (distance <= hitRange)
            {
                if (timeSinceLastAttack >= attackCooldown)
                {
                    CanMove = false;
                    DoDamage();
                    timeSinceLastAttack = 0f;
                    canAttack = false;
                }
            }
            else
            {
                CanMove = true;
            }

            if (CanMove)
            {
                Vector2 direction = player.transform.position - transform.position;
                transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            }
        }
        else
        {
            CanMove = false; // Enemy stops moving when player is out of sight range
        }

        // Update the timer
        timeSinceLastAttack += Time.deltaTime;
    }

    void DoDamage()
    {
        PlayerStats playerStats = player.GetComponent<PlayerStats>();

        if (playerStats != null)
        {
            playerStats.playerHP -= HitDamage;
            AudioSource.PlayOneShot(audioClip);
        }

    }
}
