using UnityEngine;

public class ShadowStalker : MonoBehaviour
{
    public float moveSpeed = 5.0f; // 移動速度
    public float stopDuration = 2.0f; // プレイヤーに当たった後の停止時間
    public float detectionRange = 5.0f; // プレイヤーを検出する距離
    public LayerMask playerLayer; // プレイヤーレイヤー

    private Transform player;
    private Rigidbody2D rb;
    private bool isChasing = false;
    private float stopTimer = 0.0f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // プレイヤータグを使ってプレイヤーを検出
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (!isChasing && distanceToPlayer <= detectionRange)
        {
            isChasing = true;
        }

        if (isChasing)
        {
            Vector3 moveDirection = (player.position - transform.position).normalized;
            rb.velocity = moveDirection * moveSpeed;
        }

        if (stopTimer > 0.0f)
        {
            rb.velocity = Vector2.zero; // 移動を停止
            stopTimer -= Time.deltaTime;
            if (stopTimer <= 0.0f)
            {
                isChasing = true; // 停止が終了したら再びプレイヤーを追跡
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isChasing = false;
            stopTimer = stopDuration; // プレイヤーに当たったら停止時間を設定
        }
    }
}

