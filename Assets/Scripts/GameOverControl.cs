using UnityEngine;
using UnityEngine.SceneManagement; // Bắt buộc phải có dòng này để chuyển cảnh

public class GameOverControl : MonoBehaviour
{
    // Hàm này sẽ được gọi khi ấn nút
    public void LoadMainMenu()
    {
        // Chuyển sang scene tên là "MainMenu"
        // (Lưu ý: Tên trong ngoặc kép phải GIỐNG HỆT tên file scene của bạn)
        SceneManager.LoadScene("MainMenu");
    }
}