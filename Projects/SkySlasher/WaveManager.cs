using System.Collections;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public WaveData[] waves; // Array of WaveData for different waves
    public EnemySpawner enemySpawner; // Reference to the EnemySpawner

    private int currentWaveIndex = 0;
    private bool isWaveActive = false;
    private float waveTimer = 0f;
    private int enemiesRemaining = 0; // Number of enemies remaining in the current wave  
    private bool isSpawningPaused = false;


    // Delegate for wave completion  
    public delegate void WaveCompletedHandler();
    public event WaveCompletedHandler WaveCompleted;

    [SerializeField] private PlayerAreaChecker playerAreaChecker;

    
    private void Start()
    {
        // Start the first wave 
        //Invoke("StartNextWave", 0.1f); // Invoke StartNextWave after a small delay

    }

    public void PauseSpawning()
    {
        isSpawningPaused = true;
    }

    public void ResumeSpawning()
    {
        isSpawningPaused = false;
    } 

    public void PlayerEnteredArea()
    {
        // Player has entered the area, proceed with starting the next wave
        StartNextWave();
    } 

    private void Update()
    {
        if (isWaveActive && !isSpawningPaused)
        {
            waveTimer -= Time.deltaTime;
            if (waveTimer <= 0f && enemiesRemaining == 0)
            { 
                // End current wave and start next wave
                StartNextWave();
            }
        } 
    }

    public void StartNextWave()
    {
        if (currentWaveIndex < waves.Length)
        {
            WaveData currentWave = waves[currentWaveIndex];

            // Reset the current enemy count
            enemySpawner.ResetEnemyCount();

            // Set enemy spawning parameters based on current wave
            enemySpawner.SpawnTimer = currentWave.SpawnInterval;
            enemySpawner.MaxEnemyCount = currentWave.MaxEnemyCount;
            enemySpawner.EnemyChancesList = currentWave.EnemyChances;

            // Start spawning enemies
            enemySpawner.StartSpawning();

            // Set remaining enemies count
            enemiesRemaining = currentWave.MaxEnemyCount;
            // Increment current wave index
            currentWaveIndex++;
            isWaveActive = true;
            isSpawningPaused = false; // Ensure spawning is not paused at the start of the wave

            // Check if there are subscribers before invoking
            if (WaveCompleted != null)
            {
                WaveCompleted.Invoke();
            }
        }

        else
        {
            // All waves are completed
            isWaveActive = false;
        }
    } 

    public void EnemyDestroyed()
    {
        enemiesRemaining--;
        if (enemiesRemaining == 0)
        {
            // Call GameManager's OnEnemiesDestroyed method
            GameManager.Instance.OnEnemiesDestroyed();
        }
    }
}