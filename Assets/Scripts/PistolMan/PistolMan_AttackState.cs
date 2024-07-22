using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolMan_AttackState : NpcState
{
    private PistolMan npc;

    public PistolMan_AttackState(NPC _npcBase, NpcStateMachine _stateMachine, string _animBoolName, PistolMan _npc) : base(_npcBase, _stateMachine, _animBoolName)
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

    private void SpawnNPC()
    {
        
    }
}
