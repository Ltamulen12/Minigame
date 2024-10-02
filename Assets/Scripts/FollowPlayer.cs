using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Transform playerTransform; 
    public float speed = 3.0f;

    private float initialYPosition; // Store the initial Y position

    // Start is called before the first frame update
    void Start()
    {
        // finds the player
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        // Check if the player GameObject was found
        if (player != null)
        {
            // Get the Transform component of the player
            playerTransform = player.transform;
        }

        // Store the initial Y position of the enemy to prevent floating
        initialYPosition = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        // Ensure the playerTransform reference is set
        if (playerTransform != null)
        {
            // Calculate the direction towards the player, only on the X and Z axes
            Vector3 direction = new Vector3(playerTransform.position.x - transform.position.x, 0, playerTransform.position.z - transform.position.z).normalized;

            // Ensure the enemy is actually far enough away to move
            float distanceToPlayer = Vector3.Distance(new Vector3(transform.position.x, 0, transform.position.z), new Vector3(playerTransform.position.x, 0, playerTransform.position.z));

            if (distanceToPlayer > 0.1f) // Small threshold to prevent jittery movement when very close
            {
                // Move towards the player, maintaining the initial Y position
                transform.position = new Vector3(transform.position.x, initialYPosition, transform.position.z) + direction * speed * Time.deltaTime;
            }
        }
    }
}