using UnityEngine;

public class EnemyHealth : Health 
{
    // Biến static dùng chung để đếm tổng số lượng kẻ địch đang sống trên màn hình
    public static int LivingEnemyCount = 0;

    void Awake()
    {
        // Khi một kẻ địch được sinh ra, cộng 1 vào tổng số
        LivingEnemyCount++;
    }

    protected override void Die()
    {
        // Khi kẻ địch này chết, trừ 1 khỏi tổng số
        LivingEnemyCount--;
        
        // Gọi hàm Die() của class cha (Health.cs) để tạo hiệu ứng nổ và hủy object
        // Đảm bảo số lượng không bao giờ bị kẹt ở số âm
        if (LivingEnemyCount < 0) 
        {
            LivingEnemyCount = 0;
        }
        base.Die();
    }
}