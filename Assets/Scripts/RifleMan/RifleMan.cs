
using UnityEngine;

public class RifleMan : NPC
{
    public float fireDuration;
    public AudioSource fireAS => GetComponent<AudioSource>();

    #region States
    public RifleMan_IdleState idleState { get; private set; }
    public RifleMan_MoveState moveState { get; private set; }
    public RifleMan_BattleState battleState { get; private set; }
    public RifleMan_AttackState attackState { get; private set; }
    public RifleMan_DeadState deadState { get; private set; }
    #endregion

    protected override void Awake()
    {
        base.Awake();

        idleState = new RifleMan_IdleState(this, stateMachine, "Idle", this);
        moveState = new RifleMan_MoveState(this, stateMachine, "Move", this);
        battleState = new RifleMan_BattleState(this, stateMachine, "Move", this);
        attackState = new RifleMan_AttackState(this, stateMachine, "Attack", this);
        deadState = new RifleMan_DeadState(this, stateMachine, "Die", this);
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
