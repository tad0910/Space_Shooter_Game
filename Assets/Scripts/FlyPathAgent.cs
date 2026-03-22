using UnityEngine;

public class FlyPathAgent : MonoBehaviour
{
    public FlyPath flyPath;
    public float flySpeed;
    private int nextIndex = 1;

    void Start()
    {
        // Khi mới ra đời, nhảy ngay vào điểm đầu tiên của đường bay
        if (flyPath != null && flyPath.waypoints.Length > 0)
        {
            transform.position = flyPath[0]; 
        }
    }

    void Update()
    {
        if (flyPath == null) return;

        // Slide 16: Hủy tàu địch khi đã bay qua hết tất cả các điểm
        if (nextIndex >= flyPath.waypoints.Length)
        {
            Destroy(gameObject);
            return;
        }

        // Nếu chưa bay tới điểm đích
        if (transform.position != flyPath[nextIndex])
        {
            FlyToNextWaypoint();
            LookAt(flyPath[nextIndex]); // Gọi hàm xoay đầu tàu
        }
        else
        {
            // Tới nơi rồi thì đổi mục tiêu sang điểm tiếp theo
            nextIndex++; 
        }
    }

    private void FlyToNextWaypoint()
    {
        // Bay từ từ đến mục tiêu
        transform.position = Vector3.MoveTowards(transform.position, flyPath[nextIndex], flySpeed * Time.deltaTime);
    }

    // Slide 9: Tính toán góc và xoay đầu tàu
    private void LookAt(Vector3 destination)
    {
        Vector3 position = transform.position;
        var lookDirection = destination - position;
        
        if (lookDirection.magnitude < 0.01f) return;
        
        // Mặc định đầu con tàu đang cắm xuống dưới (Vector3.down)
        var angle = Vector2.SignedAngle(Vector3.down, lookDirection);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}