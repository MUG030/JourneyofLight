using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Light2DAnimation : MonoBehaviour
{
    public Light2D light2D;
    [SerializeField] private float _animationSpeed = 1f;
    [SerializeField] private float _minValue = 0f;
    [SerializeField] private float _maxValue = 1f;

    private float currentValue;
    private bool isIncreasing = true;

    private void Start()
    {
        currentValue = _minValue;
    }

    private void Update()
    {
        // Innerの値を連続で変化させるアニメーション
        currentValue += (isIncreasing ? 1 : -1) * _animationSpeed * Time.deltaTime;
        currentValue = Mathf.Clamp(currentValue, _minValue, _maxValue);
        light2D.pointLightInnerRadius = currentValue;

        // 値が最大値または最小値に達したら方向を逆にする
        if (currentValue >= _maxValue || currentValue <= _minValue)
        {
            isIncreasing = !isIncreasing;
        }
    }
}
