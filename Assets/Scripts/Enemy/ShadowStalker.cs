using UnityEngine;

public class ShadowStalker : MonoBehaviour
{
    private Camera mainCamera;
    public float moveSpeed = 5.0f; // 移動速度
    public float stopDuration = 2.0f; // プレイヤーに当たった後の停止時間
    private bool isChasing = false;
    public float stopTimer = 0.0f;
    public GameObject playerObject;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        Vector3 screenPos = mainCamera.WorldToViewportPoint(transform.position);

        if (screenPos.x >= 0 && screenPos.x <= 1 && screenPos.y >= 0 && screenPos.y <= 1)
        {
            isChasing = true;
            Vector3 moveDirection = (playerObject.transform.position - transform.position).normalized;
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
            isChasing = false;
            stopTimer = stopDuration;
        }
    }
}
