using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Abstract base class for AI states
public abstract class State : MonoBehaviour
{
    // Method to be called when the state is entered
    public abstract void StateEnter();

    // Method to be called every frame while the state is active
    public abstract void StateUpdate();

    // Method to be called when the state is exited
    public abstract void StateExit();
}