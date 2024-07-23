using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcStats : MonoBehaviour
{
    public Stat damage;
    public Stat maxHealth;
    public int power;
    public int laneIndex;

    [SerializeField] private int currentHealth;
    [SerializeField] private LaneManager laneManager;

    protected virtual void Start()
    {
        currentHealth = maxHealth.GetValue();
    }

    public virtual void DoDamage(NpcStats _targetStats)
    {

        int totalDamage = damage.GetValue();
        _targetStats.TakeDamage(totalDamage);
    }

    public virtual void TakeDamage(int _damage)
    {
        currentHealth -= _damage;

        if (currentHealth <= 0)
            Die();
    }

    protected virtual void Die()
    {
        //laneManager.RemoveTroop(transform, laneIndex);
    }
}
