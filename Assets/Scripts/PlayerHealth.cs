using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int playerHealth = 2; // Player can be hit twice before game ends

    // Method to reduce player health when hit by an enemy
    public void TakeDamage()
    {
        playerHealth--;

        if (playerHealth <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        Debug.Log("Game Over!");
    }
}