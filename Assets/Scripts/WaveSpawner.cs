using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 1. ĐÃ ĐỔI TÊN: Từ Wave thành EnemyWave
[System.Serializable]
public class EnemyWave 
{
    public GameObject enemyPrefab;  
    public FlyPath path;            
    public int enemyCount;          
    public float spawnInterval;     
}

public class WaveSpawner : MonoBehaviour
{
    [Header("Wave Settings")]
    // 2. Cập nhật lại danh sách thành List<EnemyWave>
    public List<EnemyWave> waves; 
    public float timeBetweenWaves = 3f; 

    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        // 3. Cập nhật lại vòng lặp
        foreach (EnemyWave wave in waves)
        {
            for (int i = 0; i < wave.enemyCount; i++)
            {
                GameObject enemy = Instantiate(wave.enemyPrefab, wave.path[0], Quaternion.identity);

                FlyPathAgent agent = enemy.GetComponent<FlyPathAgent>();
                if (agent != null)
                {
                    agent.flyPath = wave.path;
                }

                yield return new WaitForSeconds(wave.spawnInterval);
            }

            yield return new WaitForSeconds(timeBetweenWaves);
        }
    }
}