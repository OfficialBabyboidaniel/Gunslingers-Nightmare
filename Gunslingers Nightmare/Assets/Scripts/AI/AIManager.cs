using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AIManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] [HideInInspector] public StateMachine stateMachine;
    [SerializeField] [HideInInspector] public AIAttack AIAttack;
    [SerializeField] [HideInInspector] public AIChase AIChase;
    [SerializeField] [HideInInspector] public AIDeath AIDeath;
    [SerializeField] [HideInInspector] public AIIdle AIIdle;
    // public AudioSource audioSource;
    // public AudioClip EnemyFootsteps;
    // public AudioClip Deathclip;

    private List<State> states = new List<State>();

    private bool isDead = false;

    AIStats AIStats;

    void Start()
    {
        AIAttack = gameObject.GetComponent<AIAttack>();
        AIChase = gameObject.GetComponent<AIChase>();
        AIDeath = gameObject.GetComponent<AIDeath>();
        AIIdle = gameObject.GetComponent<AIIdle>();

        stateMachine = gameObject.AddComponent<StateMachine>();
        states.Add(AIAttack);
        states.Add(AIChase);
        states.Add(AIDeath);
        states.Add(AIIdle);
        stateMachine.ChangeState(AIIdle);
    }

    // Update is called once per frame

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Bullet") && !isDead)
        {
            isDead = true;
            stateMachine.ChangeState(AIDeath);
        }
    }
}
