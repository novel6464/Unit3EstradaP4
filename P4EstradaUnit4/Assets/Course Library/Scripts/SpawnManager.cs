using UnityEngine;

public class SpawnManager : MonoBehaviour
{   public GameObject enemyPrefab; // Reference to the enemy prefab
    private float spawnRange = 9.0f; // Range within which enemies will spawn
    public int enemyCount;
    public int waveNumber = 1;
    public GameObject powerupPrefab;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
        SpawnEnemyWave(waveNumber);
        Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);

    }
    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i=0; 1< enemiesToSpawn; i++)
        {
                Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < -10) { Destroy(gameObject); }
        enemyCount = FindObjectsByType<Enemy>(FindObjectsSortMode.None).Length;
        if (enemyCount == 0)
        {
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
            waveNumber++;
            SpawnEnemyWave(waveNumber);
        }
    }
    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }
}
