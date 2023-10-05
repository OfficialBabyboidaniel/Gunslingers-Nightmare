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
        
    }

    public override void StateUpdate()
    {
        distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

        //måste kollas igenom, spöken går igenom väggar ? bra eller dåligt ?

        // RaycastHit2D hit = Physics2D.Linecast(transform.position, player.transform.position, LayerMask.GetMask("Wall"));

        // if (hit.collider == null)
        // {
        //     hasHitWall = false; // Set the flag to true if no wall is in the way
        // }
        // else
        // {
        //     hasHitWall = true;
        // }

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
            //EnemyMovingAudioSource.Play();
        }

        if (CanMove)
        {
            Debug.Log("trying to move");
            Vector2 direction = player.transform.position - transform.position;
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, EnemyChaseSpeed * Time.deltaTime);

             if (MaxSightRange >= distanceToPlayer)
            {
                Debug.Log("trying to paly chase sond");
                EnemyMovingAudioSource.clip = EnemyFootsteps;
                // Calculate the distance between the enemy and the player
                // Calculate the volume based on the distance (closer = louder, farther = quieter)

                //denna calcualtion måste kollas igenom
                float volume = 1f - (distanceToPlayer / MaxSightRange);

                // Clamp the volume to be between 0 and 1
                volume = Mathf.Clamp(volume, 0, 0.4f);



                // Set the volume of the enemy's footsteps
                EnemyMovingAudioSource.volume = volume;

                EnemyMovingAudioSource.Play();

                if(EnemyMovingAudioSource.isPlaying == true){
                    Debug.Log(EnemyMovingAudioSource.name + " is playing");
                    Debug.Log(EnemyMovingAudioSource.volume + " = volume");
                }
            }
        }
    }
    public override void StateExit()
    {
        CanMove = false;
        EnemyMovingAudioSource.Stop();
    }

    // Update is called once per frame
}

