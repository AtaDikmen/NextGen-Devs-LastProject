using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSaber_AnimationTrigger : MonoBehaviour
{
    private LightSaber lightSaber => GetComponentInParent<LightSaber>();

    private void AnimationTrigger()
    {
        lightSaber.AnimationFinishTrigger();
    }

    private void AttackTrigger()
    {
        RaycastHit hit;
        if (lightSaber.IsTargetDetected(out hit))
        {
            if (hit.transform.GetComponent<NPC>() != null)
            {
                NpcStats _target = hit.transform.GetComponent<NpcStats>();

                lightSaber.stats.DoDamage(_target);
            }
        }
    }

    private void PlayRandomAttackSFX()
    {
        AudioManager.Instance.PlaySFX(lightSaber.attackSFX[Random.Range(0, lightSaber.attackSFX.Length)], transform);
    }
}
