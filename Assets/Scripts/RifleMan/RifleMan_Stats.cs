using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleMan_Stats : NpcStats
{
    private RifleMan rifleMan;

    protected override void Start()
    {
        base.Start();

        rifleMan = GetComponent<RifleMan>();
    }

    public override void TakeDamage(int _damage)
    {
        base.TakeDamage(_damage);

        rifleMan.DamageEffect();
    }

    protected override void Die()
    {
        base.Die();
        rifleMan.Die();
    }
}
