using UnityEngine;

public class ShadowStalker : MonoBehaviour
{
    private Camera mainCamera;
    private Transform player;
    private float moveSpeed = 5.0f; // 移動速度
    private float stopDuration = 2.0f; // プレイヤーに当たった後の停止時間
    private bool isChasing = false;
    private float stopTimer = 0.0f;

    void Start()
    {
        mainCamera = Camera.main;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        Vector3 screenPos = mainCamera.WorldToViewportPoint(transform.position);

        // ゲームオブジェクトが画面内にいるかをチェック
        if (screenPos.x >= 0 && screenPos.x <= 1 && screenPos.y >= 0 && screenPos.y <= 1)
        {
            // 画面内にいる場合の処理
            isChasing = true;
            Vector3 moveDirection = (player.position - transform.position).normalized;
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

            if (stopTimer > 0.0f)
            {
                stopTimer -= Time.deltaTime;
                if (stopTimer <= 0.0f)
                {
                    isChasing = true;
                }
            }
        }
        else
        {
            // 画面外にいる場合の処理
            isChasing = false;
            stopTimer = stopDuration;
        }
    }
}
