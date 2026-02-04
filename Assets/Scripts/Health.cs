using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Health Settings")]
    [SerializeField] private int maxHealth = 100; // Máu tối đa, chỉnh trong Inspector
    [SerializeField] private GameObject explosionVFX; // Prefab hiệu ứng nổ

    private int currentHealth; // Máu hiện tại (chỉ code được sửa)

    // Hàm khởi tạo
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Hàm nhận sát thương (Public để Bullet gọi được)
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
        // Debug để kiểm tra xem máu có trừ không
        Debug.Log(gameObject.name + " took damage. Current HP: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Hàm xử lý cái chết
    // Dùng 'virtual' để class con (Player/Enemy) có thể ghi đè (override) nếu cần logic riêng
    protected virtual void Die()
    {
        // 1. Tạo hiệu ứng nổ (nếu có gán prefab)
        if (explosionVFX != null)
        {
            Instantiate(explosionVFX, transform.position, transform.rotation);
        }

        // 2. Hủy object này khỏi game
        Destroy(gameObject);
    }
}