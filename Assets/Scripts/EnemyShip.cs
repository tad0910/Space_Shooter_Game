using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyShip : MonoBehaviour
{
    public float speed = 5f;
    public GameObject explosionPrefab; // <-- NEW: Chỗ để gắn hiệu ứng nổ

    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.y < -10f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // TRƯỜNG HỢP 1: Đâm trúng Đạn
        if (other.gameObject.name.Contains("Bullet"))
        {
            // --- NEW: Tạo vụ nổ tại vị trí tàu địch ---
            if (explosionPrefab != null)
            {
                Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            }

            Destroy(other.gameObject);
            Destroy(gameObject);
        }

        // TRƯỜNG HỢP 2: Đâm trúng Player
        else if (other.CompareTag("Player"))
        {
            // --- NEW: Tạo vụ nổ tại chỗ Player chết ---
            if (explosionPrefab != null)
            {
                Instantiate(explosionPrefab, other.transform.position, Quaternion.identity);
            }

            Destroy(other.gameObject);
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}