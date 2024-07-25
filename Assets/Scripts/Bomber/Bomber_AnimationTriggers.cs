using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomber_AnimationTriggers : MonoBehaviour
{
    private Bomber bomber => GetComponentInParent<Bomber>();

    [SerializeField] private GameObject bombPrefab;
    [SerializeField] private Transform bombSpawn;
    [SerializeField] private ParticleSystem explosionVFX;


    private void AnimationTrigger()
    {
        bomber.AnimationFinishTrigger();
    }

    private void AttackTrigger()
    {
        GameObject bombObject = Instantiate(bombPrefab, bombSpawn.position, Quaternion.identity);
        bombObject.GetComponent<Bomb>().SetupBomb(bomber, bomber.bombTarget, explosionVFX);
    }

    private void PlayerBombThrowSound()
    {
        AudioManager.Instance.PlaySFX(bomber.attackSFX[0], transform);
    }
}
