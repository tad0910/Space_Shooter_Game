using UnityEngine;

public class BattleFlow : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Health playerHealth; 
    [SerializeField] private GameObject gameOverUI; 
    [SerializeField] private GameObject gameWinUI; 
    [SerializeField] private AudioSource bgMusic; 

    private bool isGameEnded = false;
    private bool hasEnemiesSpawned = false; // Cờ theo dõi địch xuất hiện

    void Start()
    {
        // Reset bộ đếm ở Start an toàn hơn Awake
        EnemyHealth.LivingEnemyCount = 0;

        if (gameOverUI != null) gameOverUI.SetActive(false);
        if (gameWinUI != null) gameWinUI.SetActive(false);

        if (playerHealth != null)
        {
            playerHealth.onDead += OnGameOver; 
        }
    }

    void Update()
    {
        // 1. Chờ đến khi có ít nhất 1 kẻ địch trên bản đồ
        if (!hasEnemiesSpawned && EnemyHealth.LivingEnemyCount > 0)
        {
            hasEnemiesSpawned = true; 
        }

        // 2. Chỉ gọi Game Win khi: game chưa kết thúc + địch đã từng xuất hiện + địch bị diệt sạch
        if (!isGameEnded && hasEnemiesSpawned && EnemyHealth.LivingEnemyCount == 0)
        {
            OnGameWin();
        }
    }

    private void OnGameOver()
    {
        if (isGameEnded) return;
        isGameEnded = true;

        if (gameOverUI != null) gameOverUI.SetActive(true);
        if (bgMusic != null) bgMusic.Stop();
    }

    private void OnGameWin()
    {
        if (isGameEnded) return;
        isGameEnded = true;

        if (gameWinUI != null) gameWinUI.SetActive(true);
        if (bgMusic != null) bgMusic.Stop();
        
        // Chỉ ẩn tàu khi thực sự đã thắng
        if (playerHealth != null) playerHealth.gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        if (playerHealth != null)
        {
            playerHealth.onDead -= OnGameOver;
        }
    }
}