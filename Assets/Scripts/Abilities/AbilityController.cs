using UnityEngine;

public class AbilityController : MonoBehaviour
{
    [SerializeField] private GameObject[] bombAbilityGroups;
    [SerializeField] private AbilityHeal abilityHeal;

    public void UseBombAbilityOnLane(int _laneIndex, bool _isSmart)
    {
        for (int i = 0; i < bombAbilityGroups[_laneIndex].transform.childCount; i++)
        {
            bombAbilityGroups[_laneIndex].transform.GetChild(i).GetComponent<Rigidbody>().useGravity = true;
            bombAbilityGroups[_laneIndex].transform.GetChild(i).GetComponent<Rigidbody>().isKinematic = false;
            bombAbilityGroups[_laneIndex].transform.GetChild(i).GetComponent<AbilityBomb>().isSmartBomb = _isSmart;
        }
    }

    public void UseHealAbilityOnLane(int _laneIndex)
    {
        abilityHeal.ActivateHealAbility(_laneIndex);
    }
}
