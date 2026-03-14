using System; 
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Health Settings")]
    // Đổi tên thành defaultHealthPoint và để public để HealthBar đọc được
    public int defaultHealthPoint = 100; 
    [SerializeField] private GameObject explosionVFX; 

    // Đổi currentHealth thành healthPoint và để public
    public int healthPoint; 

    // KHAI BÁO SỰ KIỆN
    public Action onDead; 
    public Action onHealthChanged; // THÊM: Kênh thông báo đổi máu

    void Start()
    {
        healthPoint = defaultHealthPoint;
        
        // THÊM: Phát tín hiệu cập nhật UI lần đầu để thanh máu đầy lúc mới vào game
        onHealthChanged?.Invoke(); 
    }

    public void TakeDamage(int damage)
    {
        if (healthPoint <= 0) return; // Nếu đã chết thì không trừ máu nữa

        healthPoint -= damage;
        
        if (healthPoint < 0)
        {
            healthPoint = 0;
        }
        
        Debug.Log(gameObject.name + " took damage. Current HP: " + healthPoint);

        // THÊM: Phát tín hiệu cho HealthBar biết máu vừa thay đổi để kéo ngắn UI
        onHealthChanged?.Invoke(); 

        if (healthPoint <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        if (explosionVFX != null)
        {
            Instantiate(explosionVFX, transform.position, transform.rotation);
        }

        onDead?.Invoke();
        Destroy(gameObject);
    }
}