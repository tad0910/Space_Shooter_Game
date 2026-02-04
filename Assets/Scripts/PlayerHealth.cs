using UnityEngine;
using UnityEngine.SceneManagement; // Dùng để load lại màn chơi

// Kế thừa từ class Health cha
public class PlayerHealth : Health
{
    // Ghi đè hàm Die của cha
    protected override void Die()
    {
        // 1. Vẫn gọi base.Die() để tạo hiệu ứng nổ và hủy tàu như bình thường
        base.Die();

        // 2. Thêm logic riêng của Player:
        Debug.Log("GAME OVER !!!");
        
        // Gọi hàm Restart sau 1 giây (để kịp nhìn thấy nổ)
        // Lưu ý: Vì object bị Destroy ngay ở base.Die(), ta phải dùng cách khác để delay.
        // Tạm thời ta sẽ LoadScene ngay lập tức để em thấy hiệu quả.
        
        ReloadLevel();
    }

    void ReloadLevel()
    {
        // Load lại màn chơi hiện tại
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}