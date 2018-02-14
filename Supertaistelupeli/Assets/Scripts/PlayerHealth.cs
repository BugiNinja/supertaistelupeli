using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public float CurrentHealth;
    public float MaxHealth;


	void Start () {
        MaxHealth = 20f;
        // Resets health to full on game load
        CurrentHealth = MaxHealth;
	}

	void Update () {
        if (CurrentHealth != 0)
        {
            CurrentHealth += 0.05f;
        }
        if(CurrentHealth >= MaxHealth)
        {
            CurrentHealth = MaxHealth;
        }
        if(CurrentHealth <= 0)
        {
            CurrentHealth = 0;
        }
	}

    public void TakeDamage(float amount)
    {
        // Deduct the damage dealt from the character's health
        CurrentHealth -= amount;
        // If the character is out health, die!
        if (CurrentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        CurrentHealth = 0;
        Debug.Log("You died.");
    }
    public float GetHealth()
    {
        return (CurrentHealth);

    }
}
