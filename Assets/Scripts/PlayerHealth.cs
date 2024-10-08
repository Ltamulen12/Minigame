using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int playerHealth = 2;
    public Text gameOverText;
    public Button restartButton;

    void Start()
    {
        gameOverText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);

        restartButton.onClick.AddListener(RestartGame);
    }

    void Update()
    {
        // Check if the "R" key is pressed
        if (Input.GetKeyDown(KeyCode.R) && playerHealth <= 0)
        {
            RestartGame();
        }
    }

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
        Time.timeScale = 0f; // Stop all gameplay by pausing time
        gameOverText.gameObject.SetActive(true); // Show the "Game Over!" message
        restartButton.gameObject.SetActive(true); // Show the "Restart" button
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // Reset the time scale
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
    }
}
