using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 10;
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        Destroy(gameObject, 2f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Kiểm tra xem vật va chạm có script Health không
        Health targetHealth = other.GetComponent<Health>();

        if (targetHealth != null)
        {
            // Trừ máu đối phương
            targetHealth.TakeDamage(damage);
            
            // Hủy viên đạn ngay lập tức
            Destroy(gameObject);
        }
    }
}