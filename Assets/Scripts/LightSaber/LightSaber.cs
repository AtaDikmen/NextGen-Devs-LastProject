public class LightSaber : NPC
{
    #region States
    public LightSaber_IdleState idleState { get; private set; }
    public LightSaber_MoveState moveState { get; private set; }
    public LightSaber_BattleState battleState { get; private set; }
    public LightSaber_AttackState attackState { get; private set; }
    public LightSaber_DeadState deadState { get; private set; }
    #endregion

    protected override void Awake()
    {
        base.Awake();

        idleState = new LightSaber_IdleState(this, stateMachine, "Idle", this);
        moveState = new LightSaber_MoveState(this, stateMachine, "Move", this);
        battleState = new LightSaber_BattleState(this, stateMachine, "Battle", this);
        attackState = new LightSaber_AttackState(this, stateMachine, "Attack", this);
        deadState = new LightSaber_DeadState(this, stateMachine, "Die", this);
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
