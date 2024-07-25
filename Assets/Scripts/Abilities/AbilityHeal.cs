using UnityEngine;
using UnityEngine.TextCore.Text;

public class AbilityHeal : MonoBehaviour
{
    public LayerMask teamLayer;
    public float healAmount = 20f;
    public Vector3[] laneCenters;
    public float laneWidth = 2f;
    public float healRange = 10f;

    private void Start()
    {
        //laneCenters = new Vector3[5];
        //laneCenters[0] = new Vector3(-8, 0, 0);
        //laneCenters[1] = new Vector3(-4, 0, 0);
        //laneCenters[2] = new Vector3(0, 0, 0);
        //laneCenters[3] = new Vector3(4, 0, 0);
        //laneCenters[4] = new Vector3(8, 0, 0);
    }

    public void ActivateHealAbility(int laneIndex)
    {
        Vector3 laneCenter = laneCenters[laneIndex];

        Collider[] colliders = Physics.OverlapBox(laneCenter, new Vector3(laneWidth / 2, 1, healRange / 2), Quaternion.identity, teamLayer);

        foreach (Collider collider in colliders)
        {
            NpcStats stat = collider.GetComponent<NpcStats>();
            if (stat != null)
            {
                stat.currentHealth = stat.characterStatsSO.maxHealth.GetValue();
                stat.UpdateHealth(stat.currentHealth, stat.characterStatsSO.maxHealth.GetValue());
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (laneCenters == null) return;

        Gizmos.color = Color.green;
        foreach (Vector3 laneCenter in laneCenters)
        {
            Gizmos.DrawWireCube(laneCenter, new Vector3(laneWidth, 2, healRange));
        }
    }
}
