using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainFollowPlayer : MonoBehaviour
{
    [SerializeField] Transform playerTransform; // プレイヤーのTransform

    private ParticleSystem rainParticleSystem; // 雨のParticleSystem

    private void Start()
    {
        rainParticleSystem = GetComponent<ParticleSystem>();
    }

    private void FixedUpdate()
    {
        // プレイヤーの位置に合わせて雨のParticleSystemを移動する
        if (playerTransform != null)
        {
            transform.position = new Vector2(playerTransform.position.x, playerTransform.position.y + 10);
        }
    }
}
