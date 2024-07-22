using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
public class NPC : MonoBehaviour
{
    [SerializeField] protected string nowState;


    #region Components
    public NpcStateMachine stateMachine { get; private set; }
    public Animator animator { get; private set; }
    public Rigidbody rb { get; private set; }
    public BoxCollider npcCollider { get; private set; }
    public NpcStats stats { get; private set; }
    #endregion

    [Header("Collision Info")]
    [SerializeField] protected Transform targetCheck;
    [SerializeField] protected float targetCheckDistance;
    public LayerMask whoIsTarget;
    [SerializeField] protected float allyCheckDistance;
    [SerializeField] protected LayerMask whoIsAlly;


    [Header("Move Info")]
    public float moveSpeed;
    public float idleTime;

    [Header("Attack Info")]
    public float attackDistance;
    public float attackCooldown;
    [HideInInspector] public float lastTimeAttacked;



    protected virtual void Awake()
    {
        stateMachine = new NpcStateMachine();
    }

    protected virtual void Start()
    {
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
        npcCollider = GetComponent<BoxCollider>();
        stats = GetComponent<NpcStats>();
    }
    
    protected virtual void Update()
    {
        stateMachine.currentState.Update();
        nowState = stateMachine.currentState.ToString();
    }

    public virtual void DamageEffect()
    {
        Debug.Log(gameObject.name + " was damaged!");
    }

    #region Velocity
    public void SetZeroVelocity() => rb.velocity = new Vector2(0, 0);

    public void SetVelocity(float moveSpeed)
    {
        Vector3 direction = transform.forward * moveSpeed;
        rb.velocity = new Vector3(direction.x, rb.velocity.y, direction.z);
    }
    #endregion

    #region Collision
    public virtual bool IsTargetDetected(out RaycastHit hitInfo)
    {
        return Physics.Raycast(targetCheck.position, transform.forward, out hitInfo, targetCheckDistance, whoIsTarget);
    }

    //public bool IsTargetDetected()
    //{
    //    RaycastHit hitInfo;
    //    return IsTargetDetected(out hitInfo);
    //}

    public virtual bool IsAllyInFront(out RaycastHit hitInfo)
    {
        return Physics.Raycast(targetCheck.position, transform.forward, out hitInfo, allyCheckDistance, whoIsAlly);
    }

    protected virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(targetCheck.position, targetCheck.position + transform.forward * targetCheckDistance);

        Gizmos.color = Color.red;
        Gizmos.DrawLine(targetCheck.position, targetCheck.position + transform.forward * attackDistance);
    }

    #endregion
    public virtual void AnimationFinishTrigger() => stateMachine.currentState.AnimationFinishTrigger();

    public virtual void Die()
    {
        Destroy(gameObject, 3f);
    }
}
