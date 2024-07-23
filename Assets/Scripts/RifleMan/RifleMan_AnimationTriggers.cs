using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleMan_AnimationTriggers : MonoBehaviour
{
    private RifleMan rifleMan => GetComponentInParent<RifleMan>();

    private void AnimationTrigger()
    {
        rifleMan.AnimationFinishTrigger();
    }

    private void AttackTrigger()
    {
        RaycastHit hit;
        if (rifleMan.IsTargetDetected(out hit))
        {
            if (hit.transform.GetComponent<NPC>() != null)
            {
                NpcStats _target = hit.transform.GetComponent<NpcStats>();
                
                rifleMan.stats.DoDamage(_target);
            }
        }
    }

    private void PlayRifleSound()
    {
        AudioManager.Instance.PlaySFX(rifleMan.attackSFX[0], .1f);
    }
}
