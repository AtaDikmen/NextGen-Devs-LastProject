using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcStats : MonoBehaviour
{
    public CharacterStatsSO characterStatsSO;

    //public Stat damage;
    //public Stat maxHealth;
    public int power;
    public int laneIndex;

    [SerializeField] private float currentHealth;
    [SerializeField] private LaneManager laneManager;

    protected virtual void Start()
    {
        laneManager = FindObjectOfType<LaneManager>();

        //currentHealth = maxHealth.GetValue();
        currentHealth = characterStatsSO.maxHealth.GetValue();
    }

    public virtual void DoDamage(NpcStats _targetStats)
    {

        float totalDamage = characterStatsSO.damage.GetValue();
        _targetStats.TakeDamage((int)totalDamage);
    }

    public virtual void TakeDamage(int _damage)
    {
        currentHealth -= _damage;

        if (currentHealth <= 0)
            Die();
    }

    protected virtual void Die()
    {
        laneManager.RemoveTroop(transform, laneIndex);
    }
}
