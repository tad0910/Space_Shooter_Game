using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // 1. Khai báo biến để chứa cái khuôn đạn (Prefab)
    public GameObject bulletPrefab;

    void Update()
    {
        // --- Code di chuyển cũ ---
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10f;
        transform.position = Camera.main.ScreenToWorldPoint(mousePos);

        // --- Code bắn đạn ---
        // Khi nhấn chuột trái (0) hoặc phím Space
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Câu lệnh thần thánh: Tạo ra vật thể từ Prefab
        // Instantiate(Cái gì, Ở đâu, Xoay thế nào);
        Instantiate(bulletPrefab, transform.position, Quaternion.identity);
    }
}