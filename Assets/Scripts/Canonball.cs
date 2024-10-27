using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannonball : MonoBehaviour
{
    private GameObject targetEnemy;
    public int attackDamage = 5; // Damage dealt by the cannonball

    // Method to set the target enemy
    public void SetTarget(GameObject enemy)
    {
        targetEnemy = enemy;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == targetEnemy)
        {
            // Get the Enemy script and apply damage
            Enemy enemyScript = targetEnemy.GetComponent<Enemy>();
            if (enemyScript != null)
            {
                enemyScript.TakeDamage(attackDamage);
                Debug.Log("Attacked enemy: " + targetEnemy.name);
            }
            // Destroy the cannonball after it hits the enemy
            Destroy(gameObject);
        }
    }
}
