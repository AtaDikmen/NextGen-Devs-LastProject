using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank_AttackState : NpcState
{
    private Tank npc;
    public Tank_AttackState(NPC _npcBase, NpcStateMachine _stateMachine, string _animBoolName, Tank _npc) : base(_npcBase, _stateMachine, _animBoolName)
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

        npc.lastTimeAttacked = Time.time;
    }

    public override void Update()
    {
        base.Update();

        npc.SetZeroVelocity();

        if (triggerCalled)
            stateMachine.ChangeState(npc.battleState);
    }
}
