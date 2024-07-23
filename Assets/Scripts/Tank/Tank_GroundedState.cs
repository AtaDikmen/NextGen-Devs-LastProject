using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank_GroundedState : NpcState
{
    protected Tank npc;

    public Tank_GroundedState(NPC _npcBase, NpcStateMachine _stateMachine, string _animBoolName, Tank _npc) : base(_npcBase, _stateMachine, _animBoolName)
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