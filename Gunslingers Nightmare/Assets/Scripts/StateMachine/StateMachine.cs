using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    private State currentState;

    // Call this method to change the current state
    public void ChangeState(State newState)
    {
        if (currentState != null)
        {
            currentState.StateExit();
        }

        currentState = newState;

        if (currentState != null)
        {
            currentState.StateEnter();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState != null)
        {
            currentState.StateUpdate();

        }
    }
}

