using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomber_DeadState : NpcState
{
    private Bomber npc;

    public Bomber_DeadState(NPC _npcBase, NpcStateMachine _stateMachine, string _animBoolName, Bomber _npc) : base(_npcBase, _stateMachine, _animBoolName)
    {
        this.npc = _npc;
    }

    public override void Enter()
    {
        base.Enter();

        npc.vFX.PlayDeathVFX();

        AudioManager.Instance.PlaySFX(npc.deathSFX[Random.Range(0, npc.deathSFX.Length)], npc.transform, 0.3f);

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
