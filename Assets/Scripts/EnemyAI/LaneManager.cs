using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneManager : MonoBehaviour
{
    [SerializeField] private LaneController[] lanes;

    public void AddTroop(Transform troop, int laneIndex)
    {
        lanes[laneIndex].AddTroop(troop);
    }

    public void RemoveTroop(Transform troop, int laneIndex)
    {
        lanes[laneIndex].RemoveTroop(troop);
    }

    public bool IsLaneEmpty(int laneIndex)
    {
        return lanes[laneIndex].troopTransforms.Count == 0;
    }
}
