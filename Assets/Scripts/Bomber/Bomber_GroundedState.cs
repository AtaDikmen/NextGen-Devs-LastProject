using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomber_GroundedState : NpcState
{
    protected Bomber npc;

    public Bomber_GroundedState(NPC _npcBase, NpcStateMachine _stateMachine, string _animBoolName, Bomber _npc) : base(_npcBase, _stateMachine, _animBoolName)
    {
        this.npc = _npc;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        RaycastHit hit;
        if (npc.IsTargetDetected(out hit))
        {
            stateMachine.ChangeState(npc.battleState);
        }
    }
}
