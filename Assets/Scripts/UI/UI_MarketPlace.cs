using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_MarketPlace : MonoBehaviour
{
    [SerializeField] private CharacterStatsSO[] characterStats;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void UpgradeTroop(string _npcName)
    {
        foreach (CharacterStatsSO stat in characterStats)
        {
            if(stat.npcName == _npcName)
            {
                stat.damage.AddModifier(10);
                stat.maxHealth.AddModifier(10);
            }
        }
    }
}
