using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIChase : State
{
    // Public variables
    public GameObject player;
    public AudioSource EnemyMovingAudioSource;
    public AudioClip EnemyFootsteps;
    public bool CanMove = false;

    // Private variables
    private float hitRange;
    private float MaxSightRange;
    private float EnemyChaseSpeed;
    private float distanceToPlayer;

    // References to other components
    private AIManager AIManager;
    private AIStats StatsScript;

    // Called when the state is entered
    public override void StateEnter()
    {
        // Get references to necessary components
        StatsScript = GetComponent<AIStats>();
        AIManager = gameObject.GetComponent<AIManager>();

        // Initialize variables from StatsScript
        hitRange = StatsScript.hitRange;
        MaxSightRange = StatsScript.MaxSightRange;

        // Set up and play the enemy moving audio
        EnemyMovingAudioSource.pitch = Random.Range(0.8f, 1.2f);
        EnemyMovingAudioSource.clip = EnemyFootsteps;
        EnemyMovingAudioSource.loop = true;
        EnemyMovingAudioSource.Play();
    }

    // Called every frame while the state is active
    public override void StateUpdate()
    {
        // Update variables from StatsScript
        EnemyChaseSpeed = StatsScript.speed;
        distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

        // Check if the player is out of sight range and switch to idle state
        if (distanceToPlayer > MaxSightRange)
        {
            StateExit();
            AIManager.stateMachine.ChangeState(AIManager.AIIdle);
        }
        // Check if the player is within hit range and switch to attack state
        else if (distanceToPlayer <= hitRange)
        {
            StateExit();
            AIManager.stateMachine.ChangeState(AIManager.AIAttack);
        }
        // Move towards the player if within sight range but outside hit range
        else if (CanMove)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, EnemyChaseSpeed * Time.deltaTime);
        }
    }

    // Called when the state is exited
    public override void StateExit()
    {
        // Stop the enemy moving audio
        EnemyMovingAudioSource.Stop();
    }
}