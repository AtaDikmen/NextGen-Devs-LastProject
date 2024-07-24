using UnityEngine;

public class Bomb : MonoBehaviour
{
    private Bomber bomber;
    private Rigidbody rb;
    private Transform target;
    private bool isExplode;

    private AudioClip explosionSFX;
    private ParticleSystem explosionVFX;

    [Header("Parabolic Info")]
    private float flightDuration = 2.0f;
    private Vector3 startPosition;
    private float elapsedTime = 0.0f;

    private float height = 5.0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        startPosition = transform.position;
        
        explosionSFX = Resources.Load<AudioClip>("BombExplode");
    }

    public void SetupBomb(Bomber _bomber, Transform _target, ParticleSystem _explosionVFX)
    {
        this.bomber = _bomber;
        this.target = _target;
        this.explosionVFX = _explosionVFX;
    }

    private void Update()
    {
        if (target != null)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / flightDuration;

            Vector3 currentPosition = CalculateParabolicPath(startPosition, target.position, t);
            transform.position = currentPosition;

            if (t >= 1.0f)
            {
                DealDamageAndDestroy();
            }
        }
    }

    private Vector3 CalculateParabolicPath(Vector3 start, Vector3 end, float t)
    {
        float parabolicT = t * 2 - 1;
        Vector3 travelDirection = end - start;
        Vector3 levelDirection = travelDirection;
        levelDirection.y = 0;
        Vector3 result = start + t * travelDirection;
        result.y += (-parabolicT * parabolicT + 1) * height;
        return result;
    }

    private void DealDamageAndDestroy()
    {
        if (isExplode) return;

        isExplode = true;

        AudioManager.Instance.PlaySFX(explosionSFX, transform, 0.2f);

        Instantiate(explosionVFX, transform.position, Quaternion.identity);

        Collider[] colliders = Physics.OverlapSphere(transform.position, 2);
        foreach (Collider nearbyObject in colliders)
        {
            if (bomber.whoIsTarget == (bomber.whoIsTarget | (1 << nearbyObject.gameObject.layer)))
            {
                NpcStats _target = nearbyObject.transform.GetComponent<NpcStats>();

                if(bomber != null)
                    bomber.stats.DoDamage(_target);
            }
        }

        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (bomber.whoIsTarget == (bomber.whoIsTarget | (1 << other.gameObject.layer)))
        {
            DealDamageAndDestroy();
        }
    }
}
