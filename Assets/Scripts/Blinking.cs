using UnityEngine;

public class Blinking : MonoBehaviour
{
    // Khai báo biến để chứa cái ảnh
    private SpriteRenderer mySprite;

    void Start()
    {
        // Lấy thành phần SpriteRenderer (cái hình ảnh) gắn trên vật thể
        mySprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Đảo ngược trạng thái: Đang hiện -> Ẩn, Đang ẩn -> Hiện
        mySprite.enabled = !mySprite.enabled;
    }
}