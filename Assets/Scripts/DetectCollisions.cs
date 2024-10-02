using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    public int enemyHealth = 3; // Base health for the enemy
    public int bulletDamage = 1; // Damage dealt by a bullet

    // Method to initialize enemy health based on the round
    public void SetInitialHealth(int round)
    {
        // Increase health by 2 for each round
        enemyHealth = 3 + (2 * (round - 1));
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Access the PlayerHealth script and apply damage to the player
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(); // Reduce player's health
            }
            TakeDamage(1); // Enemy takes damage when colliding with the player
        }
        else if (other.CompareTag("Bullet"))
        {
            TakeDamage(bulletDamage); // Enemy takes damage from bullets
            Destroy(other.gameObject); // Destroy the bullet upon impact
        }
    }

    void TakeDamage(int damage)
    {
        enemyHealth -= damage;

        if (enemyHealth <= 0)
        {
            Destroy(gameObject); // Destroy enemy when health reaches 0
        }
    }
}