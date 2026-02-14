using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : Health
{
    // [THÊM MỚI] Biến để chứa cái bảng Game Over
    public GameObject gameOverCanvas; 

    protected override void Die()
    {
        // 1. Hiện bảng Game Over lên
        // Chúng ta làm việc này trước khi gọi base.Die() để đảm bảo nó chạy được
        if (gameOverCanvas != null)
        {
            gameOverCanvas.SetActive(true);
        }

        // 2. Gọi hàm Die của cha (để tạo hiệu ứng nổ và hủy tàu)
        base.Die();

        // [QUAN TRỌNG] Xóa hoặc comment dòng ReloadLevel() đi
        // Vì ta muốn dừng ở màn hình Game Over để người chơi bấm nút, chứ không tự load lại.
        // ReloadLevel(); 
    }

    // Hàm này tạm thời không dùng nữa, để đó hoặc xóa cũng được
    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}