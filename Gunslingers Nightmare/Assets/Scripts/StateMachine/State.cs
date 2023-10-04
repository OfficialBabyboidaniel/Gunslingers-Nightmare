using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    public abstract void StateEnter();
    public abstract void StateUpdate();
    public abstract void StateExit();

}
