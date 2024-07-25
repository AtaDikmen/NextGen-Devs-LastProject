using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.CompareTag("PlayerBase") && other.gameObject.layer == LayerMask.NameToLayer("BlueTeam"))
        {
            GameManager.Instance.PlayerHealth -= other.gameObject.GetComponent<NpcStats>().power; ; //Arbitrary value
            Debug.Log("Player base damaged!");

        }
        else if (gameObject.CompareTag("EnemyBase") && other.gameObject.layer == LayerMask.NameToLayer("RedTeam"))
        {
            GameManager.Instance.EnemyHealth -= other.gameObject.GetComponent<NpcStats>().power; //Arbitrary value
            Debug.Log("Enemy base damaged!");
        }
        Destroy(other.gameObject);
    }
}
