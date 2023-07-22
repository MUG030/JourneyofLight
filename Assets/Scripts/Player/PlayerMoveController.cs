using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    public float moveSpeed = 5f; // �v���C���[�̈ړ����x
    public float jumpForce = 10f; // �W�����v��
    public float groundCheckDistance = 0.1f; // �n�ʔ���̋���
    float horizontalInput = 0.0f;
    public LayerMask groundLayer; // �n�ʂƔ��肷�郌�C���[�}�X�N

    private float originalMoveSpeed; // �����̈ړ����x
    private float originalGravityScale; // �����̏d�̓X�P�[��

    // �n�ʂɐڐG���Ă��邩�𔻒�
    private bool isGrounded;

    private Rigidbody2D rb; // �v���C���[��Rigidbody2D�R���|�[�l���g

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        originalMoveSpeed = moveSpeed; // �����̈ړ����x��ݒ�
        originalGravityScale = rb.gravityScale; // �����̏d�̓X�P�[����ݒ�
    }

    private void Update()
    {
        // ���E�̓��͂��擾
        horizontalInput = Input.GetAxis("Horizontal");

        if (horizontalInput > 0.0f)
        {
            transform.localScale = new Vector2(1, 1);
        }
        else if (horizontalInput < 0.0f)
        {
            transform.localScale = new Vector2(-1, 1);
        }

        // �X�y�[�X�L�[����������W�����v����
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
            // �ړ������ɑ��x��K�p
            rb.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, rb.velocity.y);
        }
    }

    // �n�ʔ�����s���֐�
    private bool CheckGround()
    {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        float distance = groundCheckDistance;

        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
        return hit.collider != null;
    }

    // �W�����v����֐�
    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    public void SetMoveSpeed(float multiplier)
    {
        // �ړ����x��{���ŕύX����
        moveSpeed = originalMoveSpeed * multiplier;
    }

    public void SetGravityScale(float multiplier)
    {
        // �������x��{���ŕύX����
        rb.gravityScale = originalGravityScale * multiplier;
    }
}
