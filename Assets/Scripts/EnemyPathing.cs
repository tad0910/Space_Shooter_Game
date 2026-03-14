using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    [Header("Path Settings")]
    [SerializeField] private List<Transform> waypoints; // Danh sách các điểm bay
    [SerializeField] private float moveSpeed = 5f; // Tốc độ bay của địch

    private int waypointIndex = 0; // Điểm đến hiện tại

    void Start()
    {
        // Khi vừa sinh ra, tự động di chuyển kẻ địch đến điểm đầu tiên (Waypoint 0)
        if (waypoints != null && waypoints.Count > 0)
        {
            transform.position = waypoints[waypointIndex].position;
        }
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        // Nếu vẫn còn điểm để bay tới
        if (waypointIndex < waypoints.Count)
        {
            // Tính toán vị trí điểm đến
            Vector3 targetPosition = waypoints[waypointIndex].position;
            
            // Tính tốc độ bay trong khung hình này (để không bị giật lag)
            float movementThisFrame = moveSpeed * Time.deltaTime;
            
            // Dùng hàm MoveTowards cực kỳ thần thánh của Unity để bay từ từ tới đích
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementThisFrame);

            // Nếu đã bay chạm tới điểm đích hiện tại
            if (transform.position == targetPosition)
            {
                waypointIndex++; // Chuyển mục tiêu sang điểm tiếp theo
            }
        }
        else
        {
            // Nếu đã bay qua hết tất cả các điểm -> Hủy con tàu đi (bay ra khỏi màn hình)
            Destroy(gameObject);
        }
    }
}