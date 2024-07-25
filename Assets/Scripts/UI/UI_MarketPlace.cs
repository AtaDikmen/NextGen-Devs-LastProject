using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_MarketPlace : MonoBehaviour
{
    [SerializeField] private CharacterStatsSO[] characterStats;
    [SerializeField] private TextMeshProUGUI goldText;
    void Start()
    {
        SetGoldText();
    }

    public void UpgradeTroop(string _npcName)
    {
        foreach (CharacterStatsSO stat in characterStats)
        {
            if (stat.npcName == _npcName)
            {
                if (stat.marketPrice > PlayerPrefs.GetInt("Gold", 0)) return;
                stat.damage.AddModifier(10);
                stat.maxHealth.AddModifier(10);
                PlayerPrefs.SetInt("Gold", PlayerPrefs.GetInt("Gold", 0) - stat.marketPrice);
                SetGoldText();
            }
        }
    }

    private void SetGoldText()
    {
        goldText.text = PlayerPrefs.GetInt("Gold", 0).ToString();
    }
}
