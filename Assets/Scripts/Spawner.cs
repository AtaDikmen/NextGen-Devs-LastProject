using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Dictionary<TroopType, GameObject> troopDictionary;

    [SerializeField] private GameObject rifleMan, lightSaber;
    [SerializeField] private Transform[] spawnPositions;

    void Start()
    {
        troopDictionary = new Dictionary<TroopType, GameObject>
        {
            { TroopType.LaserSword, lightSaber },
            //{ TroopType.LaserPistol, laserPistolPrefab },
            { TroopType.LaserRifle, rifleMan }
            //{ TroopType.GranadeLauncher, grenadeLauncherPrefab },
            //{ TroopType.TankRobot, tankRobotPrefab }
        };
    }

    void Update()
    {

    }

    public void SpawnTroop(TroopType troopType, int index)
    {
        GameObject troopPrefab = GetTroopPrefab(troopType);
        if (troopPrefab != null)
        {
            Instantiate(troopPrefab, spawnPositions[index].position, Quaternion.Euler(0, 90, 0));
        }
    }

    public GameObject GetTroopPrefab(TroopType troopType)
    {
        if (troopDictionary.TryGetValue(troopType, out GameObject prefab))
        {
            return prefab;
        }
        else
        {
            Debug.LogError($"TroopType {troopType} i�in prefab bulunamad�!");
            return null;
        }
    }
}
