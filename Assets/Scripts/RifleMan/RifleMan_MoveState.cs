using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleMan_MoveState : RifleMan_GroundedState
{
    public RifleMan_MoveState(NPC _npcBase, NpcStateMachine _stateMachine, string _animBoolName, RifleMan _npc) : base(_npcBase, _stateMachine, _animBoolName, _npc)
    {
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

        npc.SetVelocity(npc.moveSpeed);
    }
}
