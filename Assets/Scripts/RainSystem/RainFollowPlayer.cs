using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainFollowPlayer : MonoBehaviour
{
    [SerializeField] Transform playerTransform; // �v���C���[��Transform

    private ParticleSystem rainParticleSystem; // �J��ParticleSystem

    private void Start()
    {
        rainParticleSystem = GetComponent<ParticleSystem>();
    }

    private void FixedUpdate()
    {
        // �v���C���[�̈ʒu�ɍ��킹�ĉJ��ParticleSystem���ړ�����
        if (playerTransform != null)
        {
            transform.position = new Vector2(playerTransform.position.x, playerTransform.position.y + 10);
        }
    }
}
