using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSaber_AttackState : NpcState
{
    private LightSaber npc;
    public LightSaber_AttackState(NPC _npcBase, NpcStateMachine _stateMachine, string _animBoolName, LightSaber _npc) : base(_npcBase, _stateMachine, _animBoolName)
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
