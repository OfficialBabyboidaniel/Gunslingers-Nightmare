using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIIdle : State
{
    // Public variables
    public GameObject player; // Reference to the player character

    // Private variables
    private float distanceToPlayer; // Distance to the player
    private float MaxSightRange; // Maximum sight range of the AI

    // References to other components
    private AIManager AIManager;

    // Called when the state is entered
    public override void StateEnter()
    {
        // Get reference to the AIManager component
        AIManager = gameObject.GetComponent<AIManager>();

        // Get reference to the AIStats component and initialize MaxSightRange
        AIStats StatsScript = GetComponent<AIStats>();
        MaxSightRange = StatsScript.MaxSightRange;
    }

    // Called when the state is exited
    public override void StateExit()
    {
        // Add any necessary cleanup code here
    }

    // Called every frame while the state is active
    public override void StateUpdate()
    {
        // Calculate the distance to the player
        distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

        // Check if the player is within sight range
        if (distanceToPlayer <= MaxSightRange)
        {
            // Exit the current state and switch to the chase state
            StateExit();
            AIManager.stateMachine.ChangeState(AIManager.AIChase);
        }
    }
}