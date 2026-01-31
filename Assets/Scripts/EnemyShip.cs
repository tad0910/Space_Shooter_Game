using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyShip : MonoBehaviour
{
    public float speed = 5f;
    public GameObject explosionPrefab;

    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.y < -10f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Contains("Bullet"))
        {
            if (explosionPrefab != null)
            {
                Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            }

            Destroy(other.gameObject);
            Destroy(gameObject);
        }

        else if (other.CompareTag("Player"))
        {
            if (explosionPrefab != null)
            {
                Instantiate(explosionPrefab, other.transform.position, Quaternion.identity);
            }

            Destroy(other.gameObject);
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}