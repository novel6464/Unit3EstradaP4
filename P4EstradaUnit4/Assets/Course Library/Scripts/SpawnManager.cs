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
       
        
        Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
        SpawnEnemyWave(waveNumber);
    }
   
    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsByType<Enemy>(FindObjectsSortMode.None).Length;
        if (enemyCount == 0)
        {
            
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation); Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
        }
       // if (transform.position.z < -10) { Destroy(gameObject); }
       
        
    }
    void SpawnEnemyWave(int enemiesToSpawn)
    {

        for (int i = 0; 1 < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
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
