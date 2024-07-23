using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleMan_DeadState : NpcState
{
    private RifleMan npc;

    public RifleMan_DeadState(NPC _npcBase, NpcStateMachine _stateMachine, string _animBoolName, RifleMan _npc) : base(_npcBase, _stateMachine, _animBoolName)
    {
        this.npc = _npc;
    }

    public override void Enter()
    {
        base.Enter();

        AudioManager.Instance.PlaySFX(npc.deathSFX[Random.Range(0, npc.deathSFX.Length)], 0.5f);

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
