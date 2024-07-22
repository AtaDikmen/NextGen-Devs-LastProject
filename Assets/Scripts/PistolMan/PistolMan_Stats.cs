using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolMan_Stats : NpcStats
{
    private PistolMan pistolMan;

    protected override void Start()
    {
        base.Start();

        pistolMan = GetComponent<PistolMan>();
    }

    public override void TakeDamage(int _damage)
    {
        base.TakeDamage(_damage);

        pistolMan.DamageEffect();
    }

    protected override void Die()
    {
        base.Die();
        pistolMan.Die();
    }
}
