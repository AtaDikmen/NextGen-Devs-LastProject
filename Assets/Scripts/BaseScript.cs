using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.CompareTag("PlayerBase") && other.gameObject.layer == LayerMask.NameToLayer("BlueTeam"))
        {
            PlayerManager.Instance.PlayerHealth -= other.gameObject.GetComponent<NpcStats>().power;
            Debug.Log("Player base damaged!");

        }
        else if (gameObject.CompareTag("EnemyBase") && other.gameObject.layer == LayerMask.NameToLayer("RedTeam"))
        {
            PlayerManager.Instance.EnemyHealth -= other.gameObject.GetComponent<NpcStats>().power;
            Debug.Log("Enemy base damaged!");
        }
        Destroy(other.gameObject);
    }
}
