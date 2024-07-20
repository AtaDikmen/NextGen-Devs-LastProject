using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcState
{
    protected NpcStateMachine stateMachine;
    protected NPC npc;

    private string animBoolName;

    protected float stateTimer;
    protected bool triggerCalled;

    public NpcState(NPC _npc, NpcStateMachine _stateMachine, string _animBoolName)
    {
        this.npc = _npc;
        this.stateMachine = _stateMachine;
        this.animBoolName = _animBoolName;
    }

    public virtual void Enter()
    {
        triggerCalled = false;
        npc.animator.SetBool(animBoolName, true);
    }

    public virtual void Update()
    {
        stateTimer -= Time.deltaTime;
    }

    public virtual void Exit()
    {
        npc.animator.SetBool(animBoolName, false);
    }
}
