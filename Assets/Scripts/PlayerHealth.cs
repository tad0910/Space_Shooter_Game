using UnityEngine;

public class PlayerHealth : Health
{

    protected override void Die()
    {
        // Các logic riêng biệt CHỈ dành cho Player khi chết có thể viết ở đây
        // Ví dụ: Phát âm thanh tiếng thét của nhân vật, rung màn hình (Camera Shake)...

        // Gọi hàm Die của class cha (Health) để: 
        // 1. Sinh ra hiệu ứng nổ
        // 2. Kích hoạt sự kiện onDead (để BattleFlow bật UI Game Over)
        // 3. Hủy object (Destroy)
        base.Die();
    }
}