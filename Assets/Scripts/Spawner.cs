using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Dictionary<TroopType, GameObject> troopDictionary;

    [SerializeField] private GameObject[] troopPrefabs;
    [SerializeField] private Transform[] spawnPositions;
    [SerializeField] private LaneManager laneManager;

    public void SpawnTroop(TroopType troopType, int index)
    {
        GameObject troopPrefab = troopPrefabs[(int)troopType];
        if (troopPrefab != null)
        {
            Instantiate(troopPrefab, spawnPositions[index].position, Quaternion.Euler(0, 90, 0));
            troopPrefab.GetComponent<NpcStats>().laneIndex = index;
            //laneManager.AddTroop(troopPrefab.transform, index);
        }
    }
}
