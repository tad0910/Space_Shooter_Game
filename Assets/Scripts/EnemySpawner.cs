using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRate = 1f;   

    private float nextSpawnTime = 0f;

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnEnemy();
            nextSpawnTime = Time.time + spawnRate;
        }
    }

    void SpawnEnemy()
    {
        float randomX = Random.Range(-2.2f, 2.2f);

        Vector3 spawnPos = new Vector3(randomX, 7f, 0);

        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }
}