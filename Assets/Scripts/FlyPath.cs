using UnityEngine;

public class FlyPath : MonoBehaviour
{
    // Dùng mảng Transform để chứa các điểm (Waypoint)
    public Transform[] waypoints; 

    // Cú pháp Indexer (Slide 5): Giúp lấy tọa độ điểm đến cực nhanh chỉ bằng lệnh flyPath[index]
    public Vector3 this[int index] => waypoints[index].position;

    // Hàm vẽ đường kẻ xanh lá trong màn hình Scene (Slide 4)
    private void OnDrawGizmos()
    {
        if (waypoints == null) return;
        
        Gizmos.color = Color.green;
        // Vẽ nối từng điểm với nhau
        for (int i = 0; i < waypoints.Length - 1; i++)
        {
            if (waypoints[i] != null && waypoints[i + 1] != null)
            {
                Gizmos.DrawLine(waypoints[i].position, waypoints[i + 1].position);
            }
        }
    }
}