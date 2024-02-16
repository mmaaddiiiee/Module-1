using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//help from chatgpt. Work in progress
public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;

    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Disable the enemy GameObject
        gameObject.SetActive(false);
    }
}

