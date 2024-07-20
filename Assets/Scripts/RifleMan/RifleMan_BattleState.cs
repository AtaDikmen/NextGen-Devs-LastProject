using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class RifleMan_BattleState : NpcState
{
    private RifleMan npc;

    public RifleMan_BattleState(NPC _npcBase, NpcStateMachine _stateMachine, string _animBoolName, RifleMan _npc) : base(_npcBase, _stateMachine, _animBoolName)
    {
        this.npc = _npc;
    }

    public override void Enter()
    {
        base.Enter();
    }


    public override void Update()
    {
        base.Update();

        npc.SetVelocity(npc.moveSpeed);

        RaycastHit allyHit;
        RaycastHit hit;

        if (npc.IsAllyInFront(out allyHit))
        {
            npc.SetZeroVelocity();
        }
        if (npc.IsTargetDetected(out hit))
        {
            if (hit.distance < npc.attackDistance)
            {
                if(hit.distance < 2)
                    npc.SetZeroVelocity();

                if (CanAttack())
                    stateMachine.ChangeState(npc.attackState);
            }
        }
        else
        {
            stateMachine.ChangeState(npc.moveState);
        }
    }
    public override void Exit()
    {
        base.Exit();
    }

    private bool CanAttack()
    {
        if (Time.time >= npc.lastTimeAttacked + npc.attackCooldown)
        {
            npc.lastTimeAttacked = Time.time;
            return true;
        }

        return false;
    }
}
