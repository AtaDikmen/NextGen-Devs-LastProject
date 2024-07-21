using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSaber_DeadState : NpcState
{
    private LightSaber npc;
    public LightSaber_DeadState(NPC _npcBase, NpcStateMachine _stateMachine, string _animBoolName, LightSaber _npc) : base(_npcBase, _stateMachine, _animBoolName)
    {
        this.npc = _npc;
    }

    public override void Enter()
    {
        base.Enter();

        npc.npcCollider.enabled = false;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        npc.SetZeroVelocity();
    }
}
