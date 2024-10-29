using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAttack : State
{
    // Public variables
    public GameObject player;
    public AudioClip PlayerTakeDamage;
    public AudioClip playerDeath;
    public AudioClip EnemyAttack;
    public AudioSource AudioSource;

    // Private variables
    private float timeSinceLastAttack;
    private float attackCooldown;
    private int HitDamage;
    private float distanceToPlayer;
    private float hitRange;
    private bool hasWaitedForAttackFunction;
    private bool hasPlayedDeathSound = false;

    // References to other components
    private AIManager AIManager;
    private PlayerStats playerStats;
    private AIStats StatsScript;

    // Called when the state is entered
    public override void StateEnter()
    {
        // Get references to necessary components
        StatsScript = gameObject.GetComponent<AIStats>();
        AIManager = gameObject.GetComponent<AIManager>();
        playerStats = player.GetComponent<PlayerStats>();

        // Initialize variables
        hitRange = StatsScript.hitRange;
        timeSinceLastAttack = attackCooldown;
        hasWaitedForAttackFunction = true;
    }

    // Called every frame while the state is active
    public override void StateUpdate()
    {
        // Update variables from StatsScript
        HitDamage = StatsScript.HitDamage;
        attackCooldown = StatsScript.attackCooldown;
        distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

        // Check if the player is dead and play death sound
        if (playerStats.playerHP <= 0 && !hasPlayedDeathSound)
        {
            AudioSource.PlayOneShot(playerDeath);
            hasPlayedDeathSound = true;
            Invoke("ChangeStateIdle", playerDeath.length);
        }

        // Check if the player is out of range and switch to chase state
        if (distanceToPlayer > hitRange && hasWaitedForAttackFunction)
        {
            StateExit();
            AIManager.stateMachine.ChangeState(AIManager.AIChase);
        }

        // Check if it's time to attack
        if (timeSinceLastAttack >= attackCooldown && playerStats.playerHP > 0)
        {
            DoDamage();
            hasWaitedForAttackFunction = false;
            timeSinceLastAttack = 0f;
        }

        // Update the attack timer
        timeSinceLastAttack += Time.deltaTime;
    }

    // Perform the attack
    void DoDamage()
    {
        // Stop any currently playing audio
        AudioSource.Stop();

        // Set a random pitch for the attack sound
        float randomPitch = Random.Range(0.8f, 1.2f);
        AudioSource.pitch = randomPitch;

        // Play the attack sound
        float delay = EnemyAttack.length;
        AudioSource.PlayOneShot(EnemyAttack);

        // Schedule the damage sound to play after the attack sound
        Invoke("PlayTakeDamageSound", delay);
    }

    // Play the damage sound and apply damage to the player
    private void PlayTakeDamageSound()
    {
        // Check if the player is out of range and switch to chase state
        if (distanceToPlayer > hitRange)
        {
            StateExit();
            AIManager.stateMachine.ChangeState(AIManager.AIChase);
        }
        else
        {
            // Apply damage to the player if they are still alive
            if (playerStats.playerHP > 0 && playerStats != null)
            {
                AudioSource.pitch = 1;
                playerStats.playerHP -= HitDamage;
                AudioSource.PlayOneShot(PlayerTakeDamage);
            }
            hasWaitedForAttackFunction = true;
        }
    }

    // Called when the state is exited
    public override void StateExit()
    {
        // Add any necessary cleanup code here
    }

    // Change the state to idle
    void ChangeStateIdle()
    {
        AIManager.stateMachine.ChangeState(AIManager.AIIdle);
    }
}