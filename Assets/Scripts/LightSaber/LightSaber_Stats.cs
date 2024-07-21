using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSaber_Stats : NpcStats
{
    private LightSaber lightSaber;

    protected override void Start()
    {
        base.Start();

        lightSaber = GetComponent<LightSaber>();
    }

    public override void TakeDamage(int _damage)
    {
        base.TakeDamage(_damage);

        lightSaber.DamageEffect();
    }

    protected override void Die()
    {
        base.Die();
        lightSaber.Die();
    }
}
