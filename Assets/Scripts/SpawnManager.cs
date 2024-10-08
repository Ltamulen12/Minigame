using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public GameObject[] enemySpawnPoints;
    public int initialEnemiesPerWave = 5;
    private int currentWaveEnemies;
    private int totalEnemiesSpawned;
    private List<GameObject> spawnedEnemies = new List<GameObject>();
    private float spawnInterval = 1.5f;
    private int roundCounter = 1;

    public Text roundCounterText;

    void Start()
    {
        UpdateRoundCounterUI();
        StartCoroutine(SpawnWave(roundCounter));
    }

    // Update is called once per frame
    void Update()
    {
        // Check if all enemies are destroyed
        spawnedEnemies.RemoveAll(enemy => enemy == null); // Destroy enemies after they lose all health
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
        // Choose a random spawn point 
        int spawnIndex = Random.Range(0, enemySpawnPoints.Length);
        Transform spawnPoint = enemySpawnPoints[spawnIndex].transform;

        int enemyIndex = Random.Range(0, enemyPrefabs.Length);
        GameObject enemy = Instantiate(enemyPrefabs[enemyIndex], spawnPoint.position, spawnPoint.rotation);
        spawnedEnemies.Add(enemy);

        // Set enemy health based on the current round
        DetectCollisions enemyScript = enemy.GetComponent<DetectCollisions>();
        if (enemyScript != null)
        {
            enemyScript.SetInitialHealth(roundCounter);
        }
    }

    // Function to update the round counter
    void UpdateRoundCounterUI()
    {
        if (roundCounterText != null)
        {
            roundCounterText.text = "Round: " + roundCounter;
        }
    }
}