using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcStateMachine
{
    public NpcState currentState {  get; private set; }

    public void Initialize(NpcState _startState)
    {
        currentState = _startState;
        currentState.Enter();
    }

    public void ChangeState(NpcState _newState)
    {
        currentState.Exit();
        currentState = _newState;
        currentState.Enter();
    }
}
