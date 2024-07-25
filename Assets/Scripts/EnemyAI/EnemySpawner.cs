using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemyPrefabs;
    [SerializeField] private LaneManager laneManager;
    private List<LaneController> laneControllers;
    [SerializeField] private Transform[] spawnPositions;
    private float spawnRate;
    private float tankSpawnRate;
    private Dictionary<LaneController, int> enemyCounts = new Dictionary<LaneController, int>(); // To keep track of how many enemies are in each lane
    private Dictionary<LaneController, int> enemyPowers = new Dictionary<LaneController, int>(); // To keep track of total enemy power in each lane
    [SerializeField] private List<GameObject> enabledPrefabs = new List<GameObject>();

    void Start()
    {
        laneControllers = laneManager.GetLanes();
        foreach (var lane in laneControllers)
        {
            enemyCounts[lane] = 0;
            enemyPowers[lane] = 0;
        }

        enabledPrefabs.Add(enemyPrefabs[0]);
        StartCoroutine(EnablePrefabsOverTime());

        if (GameManager.Instance.currentMode == GameModes.Normal || GameManager.Instance.currentMode == GameModes.Easy)
        {
            spawnRate = 5.0f;
            tankSpawnRate = 45.0f;
        }
        else if (GameManager.Instance.currentMode == GameModes.Hardcore)
        {
            spawnRate = 3.0f;
            tankSpawnRate = 30.0f;
        }

        InvokeRepeating("SpawnRandomEnemy", 5f, spawnRate);
        InvokeRepeating("SpawnTank", 32f, tankSpawnRate);
    }

    private IEnumerator EnablePrefabsOverTime()
    {
        for (int i = 1; i < enemyPrefabs.Count-1; i++)
        {
            yield return new WaitForSeconds(10f); //enemies are enabled at 10 second intervals
            enabledPrefabs.Add(enemyPrefabs[i]);
        }
    }

    public void SpawnRandomEnemy()
    {
        LaneController targetLane = GetTargetLane();
        if (targetLane != null)
        {
            GameObject enemy = Instantiate(enabledPrefabs[Random.Range(0, enabledPrefabs.Count)], spawnPositions[laneControllers.IndexOf(targetLane)].position, Quaternion.Euler(0, -90, 0));
            SetEnemyProperties(enemy, targetLane);
        }
    }

    public void SpawnTank()
    {
        LaneController targetLane = GetTargetLane();
        if (targetLane != null)
        {
            GameObject enemy = Instantiate(enemyPrefabs[enemyPrefabs.Count-1], spawnPositions[laneControllers.IndexOf(targetLane)].position, Quaternion.Euler(0, -90, 0));
            SetEnemyProperties(enemy, targetLane);
        }
    }

    private void SetEnemyProperties(GameObject _enemy, LaneController _targetLane)
    {
        NpcStats npcStats = _enemy.GetComponent<NpcStats>();

        //Clone ScriptableObject to change stats only in enemy
        CharacterStatsSO originalStats = npcStats.characterStatsSO;
        CharacterStatsSO clonedStats = ScriptableObjectUtility.Clone(originalStats);
        npcStats.characterStatsSO = clonedStats;

        float difficultyMultiplier = 1f;

        if (GameManager.Instance.currentMode == GameModes.Easy)
            difficultyMultiplier = 0.8f;
        else if (GameManager.Instance.currentMode == GameModes.Hardcore)
            difficultyMultiplier = 1.5f;

        clonedStats.damage.SetValue(clonedStats.damage.GetValue() * difficultyMultiplier);
        clonedStats.maxHealth.SetValue(clonedStats.maxHealth.GetValue() * difficultyMultiplier);

        SetLayerAllChildren(_enemy.transform, "BlueTeam");
        enemyCounts[_targetLane]++;
        enemyPowers[_targetLane] += _enemy.GetComponent<NpcStats>().power;
    }

    private LaneController GetTargetLane()
    {
        LaneController highestPowerLane = null;
        int highestPower = int.MinValue;

        float randomRate = Random.Range(0.0f, 1.0f);
        Debug.Log("random rate: " + randomRate);

        // 25% chance to spawn to lane without player character
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
    public void RemoveEnemy(GameObject _enemy, int laneIndex)
    {
        LaneController lane = laneControllers[laneIndex];
        if (enemyCounts.ContainsKey(lane) && enemyCounts[lane] > 0)
        {
            enemyCounts[lane]--;
            enemyPowers[lane] -= _enemy.GetComponent<NpcStats>().power;
        }
    }

    void SetLayerAllChildren(Transform root, string layer)
    {
        var children = root.GetComponentsInChildren<Transform>();
        foreach (var child in children)
        {
            child.gameObject.layer = LayerMask.NameToLayer(layer);
        }
    }
}
