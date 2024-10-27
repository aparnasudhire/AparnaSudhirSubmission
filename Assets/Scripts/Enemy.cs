using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 20; // Health of the enemy

    // Method to take damage
    public void TakeDamage(int damageAmount)
    {
        
        health -= damageAmount;

        if (health <= 0)
        {
            Die();
        }
    }

    // Method to destroy the enemy
    void Die()
    {
        Debug.Log("Enemy " + gameObject.name + " has been killed!");
        Destroy(gameObject); // Destroy the enemy GameObject
    }
}
