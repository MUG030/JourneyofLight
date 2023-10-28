using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StokerMove : MonoBehaviour
{
    public float moveSpeed = 2.0f; // 移動速度
    public GameObject playerObject; // プレイヤーのゲームオブジェクトをドラッグ＆ドロップでアサイン
    private Transform playerTransform;
    private Camera mainCamera;

    void Start()
    {
        playerTransform = playerObject.transform;
        mainCamera = Camera.main;
    }

    void Update()
    {
        Vector3 screenPos = mainCamera.WorldToViewportPoint(transform.position);

        if (screenPos.x >= 0 && screenPos.x <= 1 && screenPos.y >= 0 && screenPos.y <= 1)
        {
            Vector2 moveDirection = (playerTransform.position - transform.position).normalized;
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

            if (moveDirection.x > 0.0f)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else if (moveDirection.x < 0.0f)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }
}
