using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of movement
    public float jumpForce = 7f; // Jump strength
    private Rigidbody rb;
    private bool isGrounded = true;
    public float weightIncreased = 0f; // Public variable to track weight


    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Freeze rotation on the X and Z axes to prevent falling over
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
    }

    void Update()
    {
        // Get player input
        float moveX = Input.GetAxis("Horizontal") * moveSpeed;
        float moveZ = Input.GetAxis("Vertical") * moveSpeed;

        // Move player
        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        rb.velocity = new Vector3(move.x, rb.velocity.y, move.z);

        // Jumping
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        // Attack
        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
        }
    }

    void Attack()
    {
        // Basic attack - can be modified later
        Debug.Log("Aparna throws a punch!");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    // Method to increase weight
    public void IncreaseWeight(float amount)
    {
        weightIncreased += amount;
        Debug.Log("Weight increased to: " + weightIncreased);
    }
        // Detect collision with the end goal (the plane)
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EndGoal"))
        {
            // Call the GameManager to trigger win condition
            GameManager gameManager = FindObjectOfType<GameManager>();
            if (gameManager != null)
            {
                gameManager.GameOver(true);
            }
        }

        if(weightIncreased > 4f){
        // Call the GameManager to trigger win condition
        GameManager gameManager = FindObjectOfType<GameManager>();
            if (gameManager != null)
            {
                gameManager.GameOver(false);
            }
        }
    }
}
