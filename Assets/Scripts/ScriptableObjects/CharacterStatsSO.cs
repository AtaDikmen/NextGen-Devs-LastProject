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
    public int marketPrice;
}

public static class ScriptableObjectUtility
{
    public static T Clone<T>(T original) where T : ScriptableObject
    {
        T clone = ScriptableObject.Instantiate(original);
        return clone;
    }
}
