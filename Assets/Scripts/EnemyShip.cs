using UnityEngine;
// Không cần SceneManager ở đây nữa, việc đó để Player lo

public class EnemyShip : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 5f;

    [Header("Combat")]
    public GameObject enemyBulletPrefab; // Kéo Prefab đạn đỏ vào đây
    public float fireRate = 2f; // Bắn 2 giây 1 phát
    private float nextFireTime = 0f;

    void Update()
    {
        // 1. Di chuyển xuống dưới
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        if (transform.position.y < -10f) Destroy(gameObject);

        // 2. Bắn súng (Code Mới)
        if (Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        if (enemyBulletPrefab != null)
        {
            // Tạo đạn ngay tại vị trí của Enemy
            Instantiate(enemyBulletPrefab, transform.position, Quaternion.identity);
        }
    }
    // Xử lý va chạm
    private void OnTriggerEnter2D(Collider2D other)
    {
        // LƯU Ý: Ta KHÔNG xử lý va chạm với Bullet ở đây.
        // Script Bullet đã tự xử lý việc đâm vào Enemy rồi (ở bài trước).
        // Ở đây ta chỉ xử lý việc ĐÂM VÀO PLAYER (Cảm tử).

        if (other.CompareTag("Player"))
        {
            // 1. Gây sát thương cho Player
            Health playerHealth = other.GetComponent<Health>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(10); // Player mất 10 máu
            }

            // 2. Enemy tự sát (Gọi TakeDamage lên chính mình)
            Health myHealth = GetComponent<Health>();
            if (myHealth != null)
            {
                myHealth.TakeDamage(9999); // Chết ngay lập tức
            }
        }
    }
}