using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UmbrellaController : MonoBehaviour
{
    public float umbrellaMoveSpeedMultiplier = 0.5f; // �P�������Ă���Ԃ̈ړ����x�̔{��
    public float umbrellaFallSpeedMultiplier = 0.5f; // �P�������Ă���Ԃ̗������x�̔{��

    private PlayerMoveController moveController; // PlayerMoveController�X�N���v�g�ւ̎Q��
    private Rigidbody2D rb; // �v���C���[��Rigidbody2D�R���|�[�l���g
    private bool isUmbrellaOpen = false; // �P���J���Ă��邩�ǂ����̃t���O

    private void Start()
    {
        moveController = GetComponent<PlayerMoveController>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // �V�t�g�L�[����������P��؂�ւ���
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isUmbrellaOpen = !isUmbrellaOpen;
            UpdateUmbrellaState();
        }
    }

    private void UpdateUmbrellaState()
    {
        if (isUmbrellaOpen)
        {
            // �P�������Ă���Ԃ̏���
            moveController.SetMoveSpeed(umbrellaMoveSpeedMultiplier); // �ړ����x�����炷
            moveController.SetGravityScale(umbrellaFallSpeedMultiplier); // �������x�����炷
        }
        else
        {
            // �P����Ă���Ԃ̏���
            moveController.SetMoveSpeed(1f); // �ړ����x�����ɖ߂�
            moveController.SetGravityScale(1f); // �������x�����ɖ߂�
        }
    }
}
