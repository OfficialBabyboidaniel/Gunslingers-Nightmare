using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIChase : State
{

    public GameObject player;
    public AudioSource EnemyMovingAudioSource;
    public AudioClip EnemyFootsteps;
    private float hitRange;
    private float MaxSightRange;
    private float EnemyChaseSpeed;
    //bool hasHitWall; ska spöken få gå igenom väggar eller inte ? 
    private float distanceToPlayer;
    public bool CanMove = false;

    AIManager AIManager;


    public override void StateEnter()
    {
        AIStats StatsScript = GetComponent<AIStats>();
        hitRange = StatsScript.hitRange;
        MaxSightRange = StatsScript.MaxSightRange;
        EnemyChaseSpeed = StatsScript.speed;
        AIManager = gameObject.GetComponent<AIManager>();
        // SoundController soundController = gameObject.GetComponent<SoundController>();
        //soundController.audioSource.Play();
        EnemyMovingAudioSource.pitch = Random.Range(0.8f, 1.2f);
        EnemyMovingAudioSource.clip = EnemyFootsteps;
        EnemyMovingAudioSource.loop = true;
        EnemyMovingAudioSource.Play();

    }

    public override void StateUpdate()
    {
        distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

        if (distanceToPlayer > MaxSightRange)
        {
            StateExit();
            AIManager.stateMachine.ChangeState(AIManager.AIIdle);
        }
        else if (distanceToPlayer <= hitRange)
        {
            StateExit();
            AIManager.stateMachine.ChangeState(AIManager.AIAttack);
        }
        else
        {
            CanMove = true;
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, EnemyChaseSpeed * Time.deltaTime);
        }


    }
    public override void StateExit()
    {
        CanMove = false;
        EnemyMovingAudioSource.pitch = 1;
        EnemyMovingAudioSource.loop = true;
        EnemyMovingAudioSource.Stop();
    }

    // Update is called once per frame
}

