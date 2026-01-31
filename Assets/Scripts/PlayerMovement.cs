using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject bulletPrefab;

    public float shootingInterval = 0.2f;  
    private float lastBulletTime;          

    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10f;
        transform.position = Camera.main.ScreenToWorldPoint(mousePos);

        if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space))
        {
            if (Time.time - lastBulletTime >= shootingInterval)
            {
                Shoot();
            }
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        
        lastBulletTime = Time.time;
    }
}