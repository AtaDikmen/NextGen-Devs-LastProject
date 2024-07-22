using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolMan_DeadState : NpcState
{
    private PistolMan npc;

    public PistolMan_DeadState(NPC _npcBase, NpcStateMachine _stateMachine, string _animBoolName, PistolMan _npc) : base(_npcBase, _stateMachine, _animBoolName)
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