using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeParticle : MonoBehaviour
{
    // このスクリプトをアタッチしたParticleSystem
    private ParticleSystem _particleSystem;

    // Offsetとして使用するGameObject
    public GameObject offsetObject;

    private void Start()
    {
        // ParticleSystemコンポーネントを取得
        _particleSystem = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        // OffsetObjectが指定されている場合、その座標をOffsetとして使用
        if (offsetObject != null)
        {
            var velocityOverLifetime = _particleSystem.velocityOverLifetime;

            // 各軸の速度を設定
            velocityOverLifetime.x = new ParticleSystem.MinMaxCurve(offsetObject.transform.position.x);
            velocityOverLifetime.y = new ParticleSystem.MinMaxCurve(offsetObject.transform.position.y);
            velocityOverLifetime.z = new ParticleSystem.MinMaxCurve(offsetObject.transform.position.z);
        }
    }

}
