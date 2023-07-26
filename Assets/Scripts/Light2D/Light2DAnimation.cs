using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Light2DAnimation : MonoBehaviour
{
    public Light2D light2D;
    [SerializeField] private float animationSpeed = 1f;
    [SerializeField] private float minValue = 0f;
    [SerializeField] private float maxValue = 1f;

    private float currentValue;
    private bool isIncreasing = true;

    private void Start()
    {
        currentValue = minValue;
    }

    private void Update()
    {
        // Innerの値を連続で変化させるアニメーション
        currentValue += (isIncreasing ? 1 : -1) * animationSpeed * Time.deltaTime;
        currentValue = Mathf.Clamp(currentValue, minValue, maxValue);
        light2D.pointLightInnerRadius = currentValue;

        // 値が最大値または最小値に達したら方向を逆にする
        if (currentValue >= maxValue || currentValue <= minValue)
        {
            isIncreasing = !isIncreasing;
        }
    }
}
