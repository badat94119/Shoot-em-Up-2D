using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    [SerializeField] private float currentHealth;
    [SerializeField] private float maximumHealth;

    public float RemainingHealthPercentage
    {
        get
        {
            return currentHealth / maximumHealth;
        }
    }

    public bool IsInvincible { get; set; } 

    public void TakeDamage(float damageAmount)
    {
        if (currentHealth == 0)
        {
            return;
        }

        if (IsInvincible)
        {
            return;
        }

        currentHealth -= damageAmount;

        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
    }

    public void AddHealth(float amountToAdd) 
    {
        if (currentHealth == maximumHealth)
        {
            return;
        }

        currentHealth += amountToAdd;

        if (currentHealth > maximumHealth)
        {
            currentHealth = maximumHealth;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
