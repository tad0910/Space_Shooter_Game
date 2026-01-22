using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject bulletPrefab;

    // --- 1. THÊM 2 BIẾN NÀY ĐỂ BẮN TỰ ĐỘNG ---
    public float shootingInterval = 0.2f; // Tốc độ bắn (0.2 giây 1 viên)
    private float lastBulletTime;         // Biến đếm thời gian

    void Update()
    {
        // --- Code di chuyển cũ (Giữ nguyên) ---
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10f;
        transform.position = Camera.main.ScreenToWorldPoint(mousePos);

        // --- Code bắn đạn (ĐÃ NÂNG CẤP) ---
        // Đổi từ GetMouseButtonDown -> GetMouseButton (Để giữ chuột là bắn)
        // Thêm điều kiện Input.GetKey(KeyCode.Space) nếu muốn giữ Space
        if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space))
        {
            // Kiểm tra xem đã "hồi chiêu" xong chưa
            if (Time.time - lastBulletTime >= shootingInterval)
            {
                Shoot();
            }
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        
        // --- 2. CẬP NHẬT LẠI THỜI GIAN ---
        lastBulletTime = Time.time;
    }
}