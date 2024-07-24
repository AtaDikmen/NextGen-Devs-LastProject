using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridManager : MonoBehaviour
{
    public GameObject troopImageParentPrefab;
    public List<GameObject> troopImagePrefabs;
    public GridLayoutGroup gridPanel;
    private List<TroopImage> troopImages;
    [SerializeField] private int gridSize = 16;
    [SerializeField] private int spawnCount = 2;

    public static GridManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        troopImages = new List<TroopImage>();
        InitializeGrid();
    }
    private void InitializeGrid()
    {
        for (int i = 0; i < gridSize; i++)
        {
            GameObject newTroop = Instantiate(troopImageParentPrefab, gridPanel.gameObject.transform);
            TroopImage newTroopImage = newTroop.GetComponent<TroopImage>();
            troopImages.Add(newTroopImage);
            newTroopImage.Initialize(TroopType.LaserSword);
        }
    }
    public void SpawnTroopsOnUI()
    {
        int tempSpawnCount = 0;
        int i = 0;
        while (tempSpawnCount < spawnCount && i < gridSize)
        {
            if (!troopImages[i].GetChildObject().activeSelf)
            {
                troopImages[i].ActivateChild();
                tempSpawnCount++;
            }
            i++;
        }
        if (tempSpawnCount > 0)
        {
            AudioClip declineMergeSFX = Resources.Load<AudioClip>("Spawn");
            AudioManager.Instance.PlaySFX(declineMergeSFX);
        }

    }
}
