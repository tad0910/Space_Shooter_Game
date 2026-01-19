using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;

    void Update()
    {
        // Bay thẳng lên trên
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        // Tự hủy sau 2 giây
        Destroy(gameObject, 2f);
    }
}