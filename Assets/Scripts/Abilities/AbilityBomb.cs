using System.Collections;
using UnityEngine;

public class AbilityBomb : MonoBehaviour
{
    //SmartBomb
    public LayerMask whoIsTarget;
    public bool isSmartBomb;

    private Transform defaultPosition;
    [SerializeField] private ParticleSystem explosionVFX;
    [SerializeField] private AudioClip explosionSFX;
    private bool isExplode;

    private void Start()
    {
        defaultPosition = transform;
        explosionSFX = Resources.Load<AudioClip>("BombExplode");

        StartCoroutine(SetDisableAfterTime());
    }

    private void OnTriggerEnter(Collider other)
    {
        Explosion();
    }

    private IEnumerator SetDisableAfterTime()
    {
        yield return new WaitForSeconds(3);

        transform.position = defaultPosition.position;

        yield return new WaitForSeconds(3);

        gameObject.transform.parent.gameObject.SetActive(false);
    }

    private void Explosion()
    {
        if (isExplode) return;

        AudioManager.Instance.PlaySFX(explosionSFX, transform);

        Instantiate(explosionVFX, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z)  , Quaternion.identity);

        isExplode = true;

        Collider[] colliders = Physics.OverlapSphere(transform.position, 4);
        foreach (Collider nearbyObject in colliders)
        {
            if (nearbyObject.gameObject.CompareTag("NPC") && !isSmartBomb)
            {
                Destroy(nearbyObject.gameObject);
            }
            else if (whoIsTarget == (whoIsTarget | (1 << nearbyObject.gameObject.layer)) && isSmartBomb)
            {
                Destroy(nearbyObject.gameObject);
            }
        }
    }

}
