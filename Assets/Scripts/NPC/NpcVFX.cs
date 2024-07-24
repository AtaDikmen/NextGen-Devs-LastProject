using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcVFX : MonoBehaviour
{
    [Header("VFX Info")]
    [SerializeField] private ParticleSystem deathVFX;
    

    public void PlayDeathVFX()
    {
        deathVFX.Play();
    }
}
