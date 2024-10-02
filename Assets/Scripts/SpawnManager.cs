using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // For UI elements

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public float spawnRangeX = 5;
    public float spawnPosZ = 20;
    public float spawnHeight = 0.1f;
    public int initialEnemiesPerWave = 5; // Number of enemies in the first wave
    private int currentWaveEnemies; // Current wave enemies
    private int totalEnemiesSpawned; // Total enemies spawned in current wave
    private List<GameObject> spawnedEnemies = new List<GameObject>(); // List to track spawned enemies
    private float spawnInterval = 1.5f;
    private int roundCounter = 1; // Round counter

    // Reference to the Text UI element
    public Text roundCounterText;

    // Start is called before the first frame update
    void Start()
    {
        UpdateRoundCounterUI();
        StartCoroutine(SpawnWave(roundCounter));
    }

    // Update is called once per frame
    void Update()
    {
        // Check if all enemies are destroyed
        spawnedEnemies.RemoveAll(enemy => enemy == null); // destroys enemies after they lose all health
        if (spawnedEnemies.Count == 0 && totalEnemiesSpawned == currentWaveEnemies)
        {
            // Go to next round
            roundCounter++;
            UpdateRoundCounterUI(); // Update the round counter each round
            StartCoroutine(SpawnWave(roundCounter));
        }
    }

    IEnumerator SpawnWave(int wave)
    {
        currentWaveEnemies = initialEnemiesPerWave + (wave - 1); // Increase enemies per wave
        totalEnemiesSpawned = 0;

        for (int i = 0; i < currentWaveEnemies; i++)
        {
            SpawnRandomEnemy();
            totalEnemiesSpawned++;
            yield return new WaitForSeconds(spawnInterval); // Wait before spawning the next enemy
        }
    }

    void SpawnRandomEnemy()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), spawnHeight, spawnPosZ);
        int enemyIndex = Random.Range(0, enemyPrefabs.Length);

        GameObject enemy = Instantiate(enemyPrefabs[enemyIndex], spawnPos, enemyPrefabs[enemyIndex].transform.rotation);
        spawnedEnemies.Add(enemy);

        // Set enemy health based on the current round
        DetectCollisions enemyScript = enemy.GetComponent<DetectCollisions>();
        if (enemyScript != null)
        {
            enemyScript.SetInitialHealth(roundCounter);
        }
    }

    // Function to update the round counter in the UI
    void UpdateRoundCounterUI()
    {
        if (roundCounterText != null)
        {
            roundCounterText.text = "Round: " + roundCounter;
        }
    }
}