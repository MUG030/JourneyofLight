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
        // Inner�̒l��A���ŕω�������A�j���[�V����
        currentValue += (isIncreasing ? 1 : -1) * animationSpeed * Time.deltaTime;
        currentValue = Mathf.Clamp(currentValue, minValue, maxValue);
        light2D.pointLightInnerRadius = currentValue;

        // �l���ő�l�܂��͍ŏ��l�ɒB������������t�ɂ���
        if (currentValue >= maxValue || currentValue <= minValue)
        {
            isIncreasing = !isIncreasing;
        }
    }
}
