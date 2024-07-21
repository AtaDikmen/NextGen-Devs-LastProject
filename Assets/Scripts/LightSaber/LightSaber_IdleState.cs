using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSaber_IdleState : LightSaber_GroundedState
{
    public LightSaber_IdleState(NPC _npcBase, NpcStateMachine _stateMachine, string _animBoolName, LightSaber _npc) : base(_npcBase, _stateMachine, _animBoolName, _npc)
    {
    }

    public override void Enter()
    {
        base.Enter();

        npc.SetZeroVelocity();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        RaycastHit allyHit;
        RaycastHit hit;
        if (npc.IsAllyInFront(out allyHit))
        {
            npc.SetZeroVelocity();
        }
        else if (npc.IsTargetDetected(out hit))
        {
            stateMachine.ChangeState(npc.battleState);
        }
        else
        {
            stateMachine.ChangeState(npc.moveState);
        }
    }
}
