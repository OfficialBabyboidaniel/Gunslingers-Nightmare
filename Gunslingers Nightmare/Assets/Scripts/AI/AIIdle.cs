using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIIdle : State
{
    public GameObject player;
    private float distanceToPlayer;

    AIManager AIManager;
    private float MaxSightRange;

    public override void StateEnter()
    {
        AIManager = GetComponent<AIManager>();
        AIStats StatsScript = GetComponent<AIStats>();
        MaxSightRange = StatsScript.MaxSightRange;
    }

    public override void StateExit()
    {

    }

    public override void StateUpdate()
    {
        distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
        if (distanceToPlayer <= MaxSightRange)
        {
            StateExit();
            AIManager.stateMachine.ChangeState(AIManager.AIChase);
        }
    }
}