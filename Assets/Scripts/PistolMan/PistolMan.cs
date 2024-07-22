using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolMan : NPC
{
    #region States
    public PistolMan_IdleState idleState { get; private set; }
    public PistolMan_MoveState moveState { get; private set; }
    public PistolMan_BattleState battleState { get; private set; }
    public PistolMan_AttackState attackState { get; private set; }
    public PistolMan_DeadState deadState { get; private set; }
    #endregion

    protected override void Awake()
    {
        base.Awake();

        idleState = new PistolMan_IdleState(this, stateMachine, "Idle", this);
        moveState = new PistolMan_MoveState(this, stateMachine, "Move", this);
        battleState = new PistolMan_BattleState(this, stateMachine, "Move", this);
        attackState = new PistolMan_AttackState(this, stateMachine, "Attack", this);
        deadState = new PistolMan_DeadState(this, stateMachine, "Die", this);
    }

    protected override void Start()
    {
        base.Start();
        stateMachine.Initialize(idleState);
    }

    protected override void Update()
    {
        base.Update();
    }

    public override void Die()
    {
        base.Die();

        stateMachine.ChangeState(deadState);
    }
}
