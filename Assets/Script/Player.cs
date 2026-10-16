using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float sensitivity = 0.5f; // マウス感度
    private Vector2 lookInput;
    private float rotationX = 0f;

    // PlayerInputコンポーネントやInputAction経由で呼び出す（SendMessage方式などの場合）
    public void OnLook(InputValue value)
    {
        lookInput = value.Get<Vector2>();
    }

    void Update()
    {
        // または Update内で直接取得する場合（InputActionフィールドを保持している場合など）
        float mouseX = lookInput.x * sensitivity;
        float mouseY = lookInput.y * sensitivity;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(-90, rotationX, 90f); // 上下の角度制限

        // カメラ（上下回転）
        transform.localRotation = Quaternion.Euler(0f, rotationX, 0f);

        // プレイヤー本体（左右回転）
        transform.parent.Rotate(Vector3.up * mouseX);
    }
}
