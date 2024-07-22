using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneController : MonoBehaviour
{
    public List<Transform> troopTransforms = new List<Transform>();
    private int totalPower;

    private void Start()
    {
        foreach(Transform troop in troopTransforms)
        {
            totalPower += troop.GetComponent<NpcStats>().power;
        }
    }

    public void AddTroop(Transform transform)
    {
        troopTransforms.Add(transform);
        Debug.Log("toplam sayý: "+ troopTransforms.Count);
        totalPower += transform.GetComponent<NpcStats>().power;
    }

    public void RemoveTroop(Transform transform)
    {
        troopTransforms.Remove(transform);
        totalPower -= transform.GetComponent<NpcStats>().power;
    }
}
