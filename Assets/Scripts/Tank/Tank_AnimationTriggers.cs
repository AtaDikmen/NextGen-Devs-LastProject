using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank_AnimationTriggers : MonoBehaviour
{
    private Tank tank => GetComponentInParent<Tank>();

    private void AnimationTrigger()
    {
        tank.AnimationFinishTrigger();
    }

    private void AttackTrigger()
    {
        RaycastHit hit;
        if (tank.IsTargetDetected(out hit))
        {
            if (hit.transform.GetComponent<NPC>() != null)
            {
                NpcStats _target = hit.transform.GetComponent<NpcStats>();

                tank.stats.DoDamage(_target);
            }
        }
    }

    private void PlayRandomAttackSFX()
    {
        AudioManager.Instance.PlaySFX(tank.attackSFX[Random.Range(0, tank.attackSFX.Length)], transform, 0.3f);
    }
}
