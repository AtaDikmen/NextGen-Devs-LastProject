using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcStats : MonoBehaviour
{
    public CharacterStatsSO characterStatsSO;

    //public Stat damage;
    //public Stat maxHealth;
    public int power;
    public int laneIndex;

    public float currentHealth;
    [SerializeField] private LaneManager laneManager;
    private HealthBar healthBar;

    protected virtual void Start()
    {
        laneManager = FindObjectOfType<LaneManager>();
        healthBar = GetComponentInChildren<HealthBar>();
        //currentHealth = maxHealth.GetValue();
        currentHealth = characterStatsSO.maxHealth.GetValue();
    }

    public virtual void DoDamage(NpcStats _targetStats)
    {

        float totalDamage = characterStatsSO.damage.GetValue();
        _targetStats.TakeDamage((int)totalDamage);
    }

    public virtual void TakeDamage(int _damage)
    {
        currentHealth -= _damage;
        UpdateHealth(currentHealth, characterStatsSO.maxHealth.GetValue());
        if (currentHealth <= 0)
            Die();
    }

    protected virtual void Die()
    {
        if (gameObject.layer == LayerMask.NameToLayer("BlueTeam"))
            PlayerManager.Instance.CurrentPlayerGold += power / 5;
        healthBar.gameObject.SetActive(false);
        laneManager.RemoveTroop(transform, laneIndex);
    }

    public void UpdateHealth(float currentHealth, float maxHealth)
    {
        healthBar.ShowHealthBarTemporarily();
        float healthNormalized = currentHealth / maxHealth;
        healthBar.SetHealth(healthNormalized);
    }
}
