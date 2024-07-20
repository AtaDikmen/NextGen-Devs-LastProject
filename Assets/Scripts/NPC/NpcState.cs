using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcState
{
    protected NpcStateMachine stateMachine;
    protected NPC npcBase;
    protected Rigidbody rb;

    private string animBoolName;

    protected float stateTimer;
    protected bool triggerCalled;

    public NpcState(NPC _npcBase, NpcStateMachine _stateMachine, string _animBoolName)
    {
        this.npcBase = _npcBase;
        this.stateMachine = _stateMachine;
        this.animBoolName = _animBoolName;
    }

    public virtual void Enter()
    {
        rb = npcBase.rb;
        triggerCalled = false;
        npcBase.animator.SetBool(animBoolName, true);
    }

    public virtual void Update()
    {
        stateTimer -= Time.deltaTime;
    }

    public virtual void Exit()
    {
        npcBase.animator.SetBool(animBoolName, false);
    }

    public virtual void AnimationFinishTrigger()
    {
        triggerCalled = true;
    }
}
