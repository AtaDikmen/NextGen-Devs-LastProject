using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleMan_IdleState : RifleMan_GroundedState
{
    public RifleMan_IdleState(NPC _npcBase, NpcStateMachine _stateMachine, string _animBoolName, RifleMan _npc) : base(_npcBase, _stateMachine, _animBoolName, _npc)
    {
    }

    public override void Enter()
    {
        base.Enter();

        stateTimer = npc.idleTime;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (stateTimer < 0)
            stateMachine.ChangeState(npc.moveState);
    }
}
