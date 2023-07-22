using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    public float moveSpeed = 5f; // プレイヤーの移動速度
    public float jumpForce = 10f; // ジャンプ力
    public float groundCheckDistance = 0.1f; // 地面判定の距離
    float horizontalInput = 0.0f;
    public LayerMask groundLayer; // 地面と判定するレイヤーマスク

    private float originalMoveSpeed; // 初期の移動速度
    private float originalGravityScale; // 初期の重力スケール

    // 地面に接触しているかを判定
    private bool isGrounded;

    private Rigidbody2D rb; // プレイヤーのRigidbody2Dコンポーネント

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        originalMoveSpeed = moveSpeed; // 初期の移動速度を設定
        originalGravityScale = rb.gravityScale; // 初期の重力スケールを設定
    }

    private void Update()
    {
        // 左右の入力を取得
        horizontalInput = Input.GetAxis("Horizontal");

        if (horizontalInput > 0.0f)
        {
            transform.localScale = new Vector2(1, 1);
        }
        else if (horizontalInput < 0.0f)
        {
            transform.localScale = new Vector2(-1, 1);
        }

        // スペースキーを押したらジャンプする
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        isGrounded = CheckGround();

        if (isGrounded || horizontalInput != 0)
        {
            // 移動方向に速度を適用
            rb.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, rb.velocity.y);
        }
    }

    // 地面判定を行う関数
    private bool CheckGround()
    {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        float distance = groundCheckDistance;

        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
        return hit.collider != null;
    }

    // ジャンプする関数
    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    public void SetMoveSpeed(float multiplier)
    {
        // 移動速度を倍率で変更する
        moveSpeed = originalMoveSpeed * multiplier;
    }

    public void SetGravityScale(float multiplier)
    {
        // 落下速度を倍率で変更する
        rb.gravityScale = originalGravityScale * multiplier;
    }
}
