using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Cái khuôn tàu địch
    public float spawnRate = 1f;   // Tốc độ đẻ (1 giây 1 con)

    private float nextSpawnTime = 0f;

    void Update()
    {
        // Kiểm tra xem đã đến giờ đẻ chưa
        if (Time.time >= nextSpawnTime)
        {
            SpawnEnemy();
            // Hẹn giờ cho lần đẻ tiếp theo
            nextSpawnTime = Time.time + spawnRate;
        }
    }

    void SpawnEnemy()
    {
        // 1. Random vị trí X (ngẫu nhiên từ trái sang phải màn hình)
        // Màn hình rộng khoảng từ -2.5 đến 2.5 (với tỉ lệ Portrait)
        float randomX = Random.Range(-2.2f, 2.2f);

        // 2. Vị trí xuất hiện: Ở trên đỉnh màn hình (Y = 7)
        Vector3 spawnPos = new Vector3(randomX, 7f, 0);

        // 3. Đẻ ra tàu địch từ Prefab
        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }
}