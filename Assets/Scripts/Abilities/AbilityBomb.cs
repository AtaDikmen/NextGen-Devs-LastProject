using Unity.VisualScripting;
using UnityEngine;

public class AbilityBomb : MonoBehaviour
{
    //SmartBomb
    public LayerMask whoIsTarget;
    public bool isSmartBomb;

    [SerializeField] private ParticleSystem explosionVFX;
    [SerializeField] private AudioClip explosionSFX;
    private bool isExplode;

    private void Start()
    {
        explosionSFX = Resources.Load<AudioClip>("BombExplode");
    }

    private void OnTriggerEnter(Collider other)
    {
        Explosion();

        Invoke("SetDisableAfterTime", 5f);
    }

    private void SetDisableAfterTime()
    {
        if(gameObject.transform.parent.gameObject.activeSelf)
            gameObject.transform.parent.gameObject.SetActive(false);
    }

    private void Explosion()
    {
        if (isExplode) return;

        AudioManager.Instance.PlaySFX(explosionSFX, transform);

        //Instantiate(explosionVFX, new Vector3(transform.position.x, transform.position.y + 4, transform.position.z)  , Quaternion.identity);

        Debug.LogWarning("EXPLODE");

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
