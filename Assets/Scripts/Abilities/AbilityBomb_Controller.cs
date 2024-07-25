using UnityEngine;

public class AbilityBomb_Controller : MonoBehaviour
{
    [SerializeField] private GameObject[] bombAbilityGroups;

    void Start()
    {

    }

    void Update()
    {

    }

    public void UseAbilityOnLane(int _laneIndex, bool _isSmart)
    {
        bombAbilityGroups[_laneIndex].SetActive(true);

        for (int i = 0; i < bombAbilityGroups[_laneIndex].transform.childCount; i++)
        {
            bombAbilityGroups[_laneIndex].transform.GetChild(i).GetComponent<AbilityBomb>().isSmartBomb = _isSmart;
        }
    }
}
