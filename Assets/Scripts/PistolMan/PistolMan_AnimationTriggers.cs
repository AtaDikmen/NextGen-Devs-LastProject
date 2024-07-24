using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolMan_AnimationTriggers : MonoBehaviour
{
    private PistolMan pistolMan => GetComponentInParent<PistolMan>();

    private void AnimationTrigger()
    {
        pistolMan.AnimationFinishTrigger();
    }

    private void AttackTrigger()
    {
        AudioManager.Instance.PlaySFX(pistolMan.attackSFX[0], transform, .02f);

        RaycastHit hit;
        if (pistolMan.IsTargetDetected(out hit))
        {
            if (hit.transform.GetComponent<NPC>() != null)
            {
                NpcStats _target = hit.transform.GetComponent<NpcStats>();

                pistolMan.stats.DoDamage(_target);
            }
        }
    }
}
