using System.Collections;
using UnityEngine;

public class AbilityBomb : MonoBehaviour
{
    private Rigidbody rb;

    //SmartBomb
    public LayerMask whoIsTarget;
    public bool isSmartBomb;

    private Vector3 defaultPosition;
    [SerializeField] private ParticleSystem explosionVFX;
    [SerializeField] private AudioClip explosionSFX;
    private bool isExplode;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        defaultPosition = transform.position;
        explosionSFX = Resources.Load<AudioClip>("BombExplode");
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (!isExplode)
        {
            Explosion();
        }
    }

    private void SetDefaultPosition()
    {
        rb.useGravity = false;
        rb.isKinematic = true;
        transform.position = defaultPosition;
        isExplode = false;
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

        StartCoroutine(ResetPositionAfterDelay(2f));
    }

    private IEnumerator ResetPositionAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SetDefaultPosition();
    }
}
