using UnityEngine;

public class HealthBar : MonoBehaviour
{
    // Bắt buộc phải có [SerializeField] thì nó mới hiện ra ở Inspector
    [SerializeField] private RectTransform mask; 
    [SerializeField] private Health playerHealth; 
    
    private float originalWidth;

    void Start()
    {
        if (mask != null) originalWidth = mask.sizeDelta.x;

        if (playerHealth != null)
        {
            playerHealth.onHealthChanged += UpdateHealthBar;
            UpdateHealthBar();
        }
    }

    private void UpdateHealthBar()
    {
        if (mask == null || playerHealth == null) return;

        float healthPercent = (float)playerHealth.healthPoint / playerHealth.defaultHealthPoint;
        healthPercent = Mathf.Clamp01(healthPercent);
        mask.sizeDelta = new Vector2(originalWidth * healthPercent, mask.sizeDelta.y);
    }

    private void OnDestroy()
    {
        if (playerHealth != null) playerHealth.onHealthChanged -= UpdateHealthBar;
    }
}