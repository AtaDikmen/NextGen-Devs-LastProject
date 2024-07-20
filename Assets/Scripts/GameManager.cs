using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject troopImagePrefab;
    public Transform checkerboardPanel;

    public void SpawnTroops()
    {
        for (int i = 0; i < 2; i++)
        {
            GameObject newTroop = Instantiate(troopImagePrefab, checkerboardPanel);
            newTroop.GetComponent<TroopImage>().Initialize(GetRandomTroopType());
        }
    }

    private TroopType GetRandomTroopType()
    {
        Array values = Enum.GetValues(typeof(TroopType));
        System.Random random = new System.Random();
        return (TroopType)values.GetValue(random.Next(values.Length));
    }
}
