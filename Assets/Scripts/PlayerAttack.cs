using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float attackRange = 2f; // Range within which the player can attack
    public GameObject cannonballPrefab; // Reference to the cannonball prefab
    public float cannonballSpeed = 20f; // Speed of the cannonball
    public float cannonCooldown = 1f; // Cooldown time between cannon shots

    private float lastCannonTime = -1f; // Track the time since the last cannonball
    void Update()
    {
        // Check for enemies within attack range
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, attackRange);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Enemy"))
            {
                // Only throw a cannonball if cooldown has passed
                if (Time.time >= lastCannonTime + cannonCooldown)
                {
                    ThrowCannonball(hitCollider.gameObject); // Pass the enemy target to the cannonball
                    lastCannonTime = Time.time; // Update the last cannonball throw time
                }
            }
        }
    }

    // Method to throw a cannonball at the enemy
    void ThrowCannonball(GameObject enemy)
    {
        // Instantiate the cannonball at the player's position
        GameObject cannonball = Instantiate(cannonballPrefab, transform.position, Quaternion.identity);

        // Set the target on the cannonball's Cannonball script
        Cannonball cannonballScript = cannonball.GetComponent<Cannonball>();
        if (cannonballScript != null)
        {
            cannonballScript.SetTarget(enemy); // Assign the target enemy
        }

        // Calculate direction towards the enemy and apply force
        Vector3 direction = (enemy.transform.position - transform.position).normalized;
        Rigidbody rb = cannonball.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(direction * cannonballSpeed, ForceMode.Impulse);
        }
    }
}
