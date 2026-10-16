using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] Transform playerCamera; // プレイヤーのカメラ
    [SerializeField] private float sensitivity = 0.5f; // マウス感度

    private float xRotation = 0f; // カメラのX軸回転量
    private float yRotation = 0f; // カメラのY軸回転量

    private void Update()
    {
        // マウスの移動量を取得
        Vector2 mouseDelta =
            Mouse.current.delta.ReadValue();

        // 左右の視点移動
        float mouseX =
            mouseDelta.x * sensitivity;

        // 上下の視点移動
        float mouseY =
            mouseDelta.y * sensitivity;

        // 上下の回転角度を計算
        xRotation -= mouseY;
        yRotation += mouseX;

        // 上下を見すぎないように制限
        xRotation = Mathf.Clamp(xRotation, -11f, 11f);
        yRotation = Mathf.Clamp(yRotation, -35f, 35f);

        // カメラを上下に回転f
        transform.localRotation =
            Quaternion.Euler(xRotation, 0f, 0f);
        transform.localRotation = 
            Quaternion.Euler(0f, yRotation, 0f);

        // プレイヤー本体を左右に回転
        if (playerCamera != null)
        {
            playerCamera.Rotate(
                Vector3.up * mouseX
            );
        }
    }

    void OnDisable()
    {
        // スクリプトが無効になったらカーソルを戻す
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}

