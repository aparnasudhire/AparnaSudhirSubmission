using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class food : MonoBehaviour
{
    public float weightIncreased = 0;
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            // Increase the player's fatness (scale width)
            Transform playerTransform = collision.transform;
            Vector3 newScale = playerTransform.localScale;
            newScale.x += 0.2f; // Increase the player's width (X scale)
            playerTransform.localScale = newScale;
            weightIncreased++;

            // Destroy the donut after it hits the player
            Destroy(gameObject);
        }
    }
}

