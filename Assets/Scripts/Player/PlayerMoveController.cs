using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    public float moveSpeed = 5f; // プレイヤーの移動速度
    public float jumpForce = 10f; // ジャンプ力
    public float groundCheckDistance = 0.1f; // 地面判定の距離
    public float knockBackPower; //ノックバック力
    private float horizontalInput;
    public LayerMask groundLayer; // 地面と判定するレイヤーマスク

    private float _originalMoveSpeed; // 初期の移動速度
    private float _originalGravityScale; // 初期の重力スケール

    private float _controlLoseTime;

    // 地面に接触しているかを判定
    private bool _isGrounded;

    private Rigidbody2D rb; // プレイヤーのRigidbody2Dコンポーネント
    private Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        _originalMoveSpeed = moveSpeed; // 初期の移動速度を設定
        _originalGravityScale = rb.gravityScale; // 初期の重力スケールを設定
        _controlLoseTime = 0f;
    }

    private void Update()
    {
        bool isControl = _controlLoseTime <= 0;

        // 左右の入力を取得
        horizontalInput = Input.GetAxis("Horizontal");

        if (!isControl || Light.isAttack)
        {
            animator.SetFloat("Speed", 0);
            horizontalInput = 0f;
        }

        animator.SetFloat("Speed", Mathf.Abs(horizontalInput));
        
        //animator.SetBool("IsJump", true);

        

        if (horizontalInput > 0.0f)
        {
            animator.SetBool("IsWalk", _isGrounded);
            transform.localScale = new Vector2(1, 1);
        }
        else if (horizontalInput < 0.0f)
        {
            animator.SetBool("IsWalk", _isGrounded);
            transform.localScale = new Vector2(-1, 1);
        }

        // スペースキーを押したらジャンプする
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded && isControl && !Light.attackCommand)
        {
            Jump();
        }

        if (0f < _controlLoseTime)
        {
            _controlLoseTime -= Time.deltaTime;
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    private void FixedUpdate()
    {
        if (Light.isAttack)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            return;
        }
        bool isControl = _controlLoseTime <= 0;
        _isGrounded = CheckGround();

        if ((_isGrounded || horizontalInput != 0) && isControl && !Light.attackCommand)
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

        RaycastHit2D hit = Physics2D.Raycast(position + new Vector2(0f, 0.5f), direction, distance, groundLayer);

        // レイを可視化（デバッグ目的）
        Debug.DrawRay(position + new Vector2(0f, 0.5f), direction * distance, Color.red);

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
        moveSpeed = _originalMoveSpeed * multiplier;
    }

    public void SetGravityScale(float multiplier)
    {
        // 落下速度を倍率で変更する
        rb.gravityScale = _originalGravityScale * multiplier;
    }

    public void KnockBack (Vector2 direction)
    {
        if (0f > direction.x)
        {
            direction.x = -1.0f;
        } else if (0f < direction.x)
        {
            direction.x = 1.0f;
        }
        rb.velocity = Vector2.zero;
        Vector2 knockbackForce = new Vector2(direction.x * knockBackPower, 5f);

        rb.velocity = knockbackForce;
        _controlLoseTime = 1f;  // これ今後はUniTaskで処理したい。
    }
}
