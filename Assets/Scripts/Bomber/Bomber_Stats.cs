using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomber_Stats : NpcStats
{
    private Bomber bomber;

    protected override void Start()
    {
        base.Start();

        bomber = GetComponent<Bomber>();
    }

    public override void TakeDamage(int _damage)
    {
        base.TakeDamage(_damage);

        bomber.DamageEffect();
    }

    protected override void Die()
    {
        base.Die();
        bomber.Die();
    }
}
