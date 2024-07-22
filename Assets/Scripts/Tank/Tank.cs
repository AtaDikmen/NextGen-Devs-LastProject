using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : NPC
{
    #region States
    public Tank_IdleState idleState { get; private set; }
    public Tank_MoveState moveState { get; private set; }
    public Tank_BattleState battleState { get; private set; }
    public Tank_AttackState attackState { get; private set; }
    public Tank_DeadState deadState { get; private set; }
    #endregion

    protected override void Awake()
    {
        base.Awake();

        idleState = new Tank_IdleState(this, stateMachine, "Idle", this);
        moveState = new Tank_MoveState(this, stateMachine, "Move", this);
        battleState = new Tank_BattleState(this, stateMachine, "Idle", this);
        attackState = new Tank_AttackState(this, stateMachine, "Attack", this);
        deadState = new Tank_DeadState(this, stateMachine, "Die", this);
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
