using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleMan_AttackState : NpcState
{
    private RifleMan npc;

    public RifleMan_AttackState(NPC _npcBase, NpcStateMachine _stateMachine, string _animBoolName, RifleMan _npc) : base(_npcBase, _stateMachine, _animBoolName)
    {
        this.npc = _npc;
    }

    public override void Enter()
    {
        base.Enter();

        stateTimer = npc.fireDuration;

        npc.fireAS.Play();
    }

    public override void Exit()
    {
        base.Exit();

        npc.lastTimeAttacked = Time.time;
        npc.fireAS.Stop();
    }

    public override void Update()
    {
        base.Update();

        npc.SetZeroVelocity();

        if (stateTimer < 0)
            stateMachine.ChangeState(npc.battleState);
    }
}
