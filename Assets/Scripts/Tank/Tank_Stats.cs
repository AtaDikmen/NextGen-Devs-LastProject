using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank_Stats : NpcStats
{
    private Tank tank;

    protected override void Start()
    {
        base.Start();

        tank = GetComponent<Tank>();
    }

    public override void TakeDamage(int _damage)
    {
        base.TakeDamage(_damage);

        tank.DamageEffect();
    }

    protected override void Die()
    {
        base.Die();
        tank.Die();
    }
}
