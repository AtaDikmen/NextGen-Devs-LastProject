using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemyPrefabs;
    [SerializeField] private LaneManager laneManager;
    [SerializeField] private List<LaneController> laneControllers;
    [SerializeField] private Transform[] spawnPositions;
    private Dictionary<LaneController, int> enemyCounts = new Dictionary<LaneController, int>(); // To keep track of how many enemies are in each lane
    private Dictionary<LaneController, int> enemyPowers = new Dictionary<LaneController, int>(); // To keep track of total enemy power in each lane
    private GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        laneControllers = laneManager.GetLanes();
        foreach (var lane in laneControllers)
        {
            enemyCounts[lane] = 0;
            enemyPowers[lane] = 0;
        }

        InvokeRepeating("SpawnEnemy", 5.0f, 3.0f);
    }

    public void SpawnEnemy()
    {
        LaneController targetLane = GetTargetLane();
        if (targetLane != null)
        {
            enemy = Instantiate(enemyPrefabs[Random.Range(0,enemyPrefabs.Count)], spawnPositions[laneControllers.IndexOf(targetLane)].position, Quaternion.Euler(0, -90, 0));
            enemyCounts[targetLane]++;
            enemyPowers[targetLane] += enemy.GetComponent<NpcStats>().power;
        }
    }

    private LaneController GetTargetLane()
    {
        LaneController highestPowerLane = null;
        int highestPower = int.MinValue;

        float randomRate = Random.Range(0.0f, 1.0f);
        Debug.Log("random rate: " + randomRate);

        // 25% chance to spawn in an empty lane
        if (randomRate < 0.25f)
        {
            foreach (LaneController lane in laneControllers)
            {
                if (lane.IsLaneEmpty())
                {
                    return lane;
                }
            }
        }

        // Prioritize lanes with player characters but no enemies
        foreach (LaneController lane in laneControllers)
        {
            if (!lane.IsLaneEmpty() && enemyCounts[lane] == 0)
            {
                Debug.Log("lane with player character but no enemy");
                return lane;
            }
        }

        // If all lanes have enemies, return the lane with the highest power
        foreach (LaneController lane in laneControllers)
        {
            if (!lane.IsLaneEmpty())
            {
                if (lane.totalPower > highestPower)
                {
                    // If enemy power is higher than total power in that lane, there is still a 20% chance to spawn an enemy
                    if (enemyPowers[lane] >= lane.totalPower)
                    {
                        float randomRateForPower = Random.Range(0.0f, 1.0f);
                        if (randomRateForPower < 0.2f)
                        {
                            highestPower = lane.totalPower;
                            highestPowerLane = lane;
                        }
                        else
                        {
                            Debug.Log("enemy power is higher than total power, cannot spawn enemy on lane index: " + laneControllers.IndexOf(lane));
                            continue;
                        }
                    }
                    highestPower = lane.totalPower;
                    highestPowerLane = lane;
                }
            }
        }

        // If all lanes are empty, return a random lane
        if (highestPowerLane == null)
        {
            int randomLaneIndex = Random.Range(0, laneControllers.Count);
            Debug.Log("random lane since each lane is empty, lane index: " + randomLaneIndex);
            return laneControllers[randomLaneIndex];
        }

        return highestPowerLane;
    }

    // Called when an enemy dies
    public void RemoveEnemy(int laneIndex)
    {
        LaneController lane = laneControllers[laneIndex];
        if (enemyCounts.ContainsKey(lane) && enemyCounts[lane] > 0)
        {
            enemyCounts[lane]--;
            enemyPowers[lane] -= enemy.GetComponent<NpcStats>().power;
        }
    }
}
