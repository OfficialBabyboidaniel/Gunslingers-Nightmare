using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// StateMachine class to manage different states of an AI character
public class StateMachine : MonoBehaviour
{
    // The current state of the state machine
    private State currentState;

    // Call this method to change the current state
    public void ChangeState(State newState)
    {
        // If there is a current state, call its StateExit method
        if (currentState != null)
        {
            currentState.StateExit();
        }

        // Set the new state as the current state
        currentState = newState;

        // If the new state is not null, call its StateEnter method
        if (currentState != null)
        {
            currentState.StateEnter();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // If there is a current state, call its StateUpdate method
        if (currentState != null)
        {
            currentState.StateUpdate();
        }
    }
}