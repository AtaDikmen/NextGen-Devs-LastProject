using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bomber : NPC
{
    public Transform bombTarget;

    #region States
    public Bomber_IdleState idleState { get; private set; }
    public Bomber_MoveState moveState { get; private set; }
    public Bomber_BattleState battleState { get; private set; }
    public Bomber_AttackState attackState { get; private set; }
    public Bomber_DeadState deadState { get; private set; }
    #endregion

    protected override void Awake()
    {
        base.Awake();

        idleState = new Bomber_IdleState(this, stateMachine, "Idle", this);
        moveState = new Bomber_MoveState(this, stateMachine, "Move", this);
        battleState = new Bomber_BattleState(this, stateMachine, "Move", this);
        attackState = new Bomber_AttackState(this, stateMachine, "Attack", this);
        deadState = new Bomber_DeadState(this, stateMachine, "Die", this);
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
