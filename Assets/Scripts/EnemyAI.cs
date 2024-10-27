using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player; // Reference to the player
    public GameObject donutPrefab; // Prefab for the tiny objects
    public float moveSpeed = 3f; // Speed at which enemy moves
    public float attackRange = 10f; // Attack when within this range
    public float moveRange = 15f; // Move when within this range (attackRange + 5)

    public float attackInterval = 2f; // Time between attacks
    private float nextAttackTime = 0f; // Timer to track when the next attack can happen

    void Update()
    {
        // Calculate the distance between the enemy and the player
        float distance = Vector3.Distance(player.position, transform.position);

        // Check if the player is within moveRange but outside the attackRange
        if (distance <= moveRange && distance > attackRange)
        {
            // Move towards the player
            MoveTowardsPlayer();
        }
        // Check if the player is within attackRange and it is time to attack
        else if (distance <= attackRange && Time.time >= nextAttackTime)
        {
            // Perform the attack
            AttackPlayer();
            nextAttackTime = Time.time + attackInterval; // Reset attack timer
        }
        else
        {
            // Idle state (optional)
            Idle();
        }
    }

    void MoveTowardsPlayer()
    {
        // Move towards the player if within moveRange but not close enough to attack
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;
    }

    void AttackPlayer()
    {
        // Instantiate donut object and throw it at the player
        Debug.Log("Enemy throws a donut at Aparna!");
        GameObject donut = Instantiate(donutPrefab, transform.position + transform.forward, Quaternion.identity);
        Rigidbody rb = donut.GetComponent<Rigidbody>();

        // Apply force to the donut to move toward the player
        Vector3 direction = (player.position - transform.position).normalized;
        rb.AddForce(direction * 10f, ForceMode.Impulse);

        // The donut will be destroyed on collision with the player (handled in another script)
    }

    void Idle()
    {
        // Enemy does nothing (idle state) when the player is outside moveRange
        Debug.Log("Enemy is idle.");
    }
}
