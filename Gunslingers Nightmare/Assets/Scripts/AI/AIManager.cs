using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AIManager : MonoBehaviour
{
    // State machine to manage AI states
    [SerializeField] [HideInInspector] public StateMachine stateMachine;

    // References to different AI states
    [SerializeField] [HideInInspector] public AIAttack AIAttack;
    [SerializeField] [HideInInspector] public AIChase AIChase;
    [SerializeField] [HideInInspector] public AIDeath AIDeath;
    [SerializeField] [HideInInspector] public AIIdle AIIdle;

    // List to hold all states
    private List<State> states = new List<State>();

    // Flag to check if the AI is dead
    private bool isDead = false;

    // Reference to AIStats component
    AIStats AIStats;

    // Start is called before the first frame update
    void Start()
    {
        // Get references to state components
        AIAttack = gameObject.GetComponent<AIAttack>();
        AIChase = gameObject.GetComponent<AIChase>();
        AIDeath = gameObject.GetComponent<AIDeath>();
        AIIdle = gameObject.GetComponent<AIIdle>();

        // Initialize the state machine and add states to the list
        stateMachine = gameObject.AddComponent<StateMachine>();
        states.Add(AIAttack);
        states.Add(AIChase);
        states.Add(AIDeath);
        states.Add(AIIdle);

        // Set the initial state to AIIdle
        stateMachine.ChangeState(AIIdle);
    }

    // Called when the AI collides with another object
    void OnCollisionEnter2D(Collision2D col)
    {
        // Check if the collision is with a bullet and the AI is not already dead
        if (col.gameObject.CompareTag("Bullet") && !isDead)
        {
            // Set the AI to dead and change the state to AIDeath
            isDead = true;
            stateMachine.ChangeState(AIDeath);
        }
    }
}