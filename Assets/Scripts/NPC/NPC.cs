using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    #region Components
    public Rigidbody rb { get; private set; }
    public Animator animator { get; private set; }
    public NpcStateMachine stateMachine { get; private set; }
    #endregion

    [Header("Collision Info")]
    [SerializeField] protected Transform targetCheck;
    [SerializeField] protected float targetCheckDistance;
    [SerializeField] protected LayerMask whatIsTarget;



    protected virtual void Awake()
    {
        stateMachine = new NpcStateMachine();
    }

    protected virtual void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }
    
    protected virtual void Update()
    {
        stateMachine.currentState.Update();
    }

    #region Velocity
    public void ZeroVelocity() => rb.velocity = new Vector2(0, 0);

    public void SetVelocity(float _xVelocity, float _yVelocity)
    {
        rb.velocity = new Vector2(_xVelocity, _yVelocity);
    }
    #endregion

    #region Collision
    public virtual bool IsTargetDetected() => Physics.Raycast(targetCheck.position, Vector2.right * transform.right, targetCheckDistance, whatIsTarget);

    protected virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(targetCheck.position, new Vector3(targetCheck.position.x + targetCheckDistance, targetCheck.position.y));
    }

    #endregion
}
