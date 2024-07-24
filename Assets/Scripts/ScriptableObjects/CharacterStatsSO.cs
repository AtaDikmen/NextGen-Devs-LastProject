using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character Stats", menuName = "Character Stats")]
public class CharacterStatsSO : ScriptableObject
{
    public string npcName;

    public Stat damage;
    public Stat maxHealth;
    public int power;
    public int laneIndex;
}
