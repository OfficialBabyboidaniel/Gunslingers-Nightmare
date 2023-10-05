using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAttack : State
{

    public GameObject player;
    public AudioClip PlayerTakeDamage;

    public AudioClip EnemyAttack;

    public AudioSource AudioSource;

    private float timeSinceLastAttack = 0f;

    private float attackCooldown;

    private int HitDamage;

    private float distanceToPlayer;

    private float hitRange;

    AIManager AIManager;
    public override void StateEnter()
    {
        AIStats StatsScript = gameObject.GetComponent<AIStats>();
        attackCooldown = StatsScript.attackCooldown;
        HitDamage = StatsScript.HitDamage;
        hitRange = StatsScript.hitRange;
        AIManager = gameObject.GetComponent<AIManager>();
    }
    public override void StateUpdate()
    {
        distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

        if (distanceToPlayer > hitRange)
        {
            StateExit();
            AIManager.stateMachine.ChangeState(AIManager.AIChase);
        }

        if (timeSinceLastAttack >= attackCooldown)
        {
            DoDamage();
            timeSinceLastAttack = 0f;
        }
        // Update the timer
        timeSinceLastAttack += Time.deltaTime;
    }
    void DoDamage()
    {
        AudioSource.Stop();

        float randomPitch = Random.Range(0.8f, 1.2f);

        // Set the pitch of the AudioSource
        AudioSource.pitch = randomPitch;

        float delay = EnemyAttack.length;

        AudioSource.PlayOneShot(EnemyAttack);

        Invoke("PlayTakeDamageSound", delay);


    }
    private void PlayTakeDamageSound()
    {

        PlayerStats playerStats = player.GetComponent<PlayerStats>();

        if (playerStats != null)
        {
            AudioSource.pitch = 1;
            playerStats.playerHP -= HitDamage;
            AudioSource.PlayOneShot(PlayerTakeDamage);
        }
    }

    public override void StateExit()
    {
        
    }
}
