using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Light : MonoBehaviour
{
    public Light2D light2D;
    [SerializeField] private float _animationSpeed = 1f;
    [SerializeField] private float _attackrate = 1f;
    [SerializeField] private float _minValue = 0f;
    [SerializeField] private float _maxValue = 1f;
    [SerializeField] private float _attackValue = 1f;

    private float _attackSpeed = 1f;
    private float currentValue;
    private bool isIncreasing = true;
    public static bool isAttack = false;
    internal Color color;

    // Start is called before the first frame update
    void Start()
    {
        currentValue = _minValue;
        Debug.Log(_attackValue);
    }

    private void Update()
    {

        // Xキーが押されたらInnerRadiusを増加させる
        if (!isAttack && Input.GetKeyDown(KeyCode.X))
        {
            currentValue = _minValue;
            _attackSpeed = _animationSpeed * _attackrate;
            isAttack = true;
            isIncreasing = true;
        }

        if (isAttack)
        {
            // Innerの値を連続で変化させるアニメーション
            currentValue += (isIncreasing ? 1 : -1) * _attackSpeed * Time.deltaTime;
            currentValue = Mathf.Clamp(currentValue, _minValue, _attackValue);
            light2D.pointLightInnerRadius = currentValue;
            Debug.Log(currentValue);

            // 値が最大値または最小値に達したら方向を逆にする
            if (currentValue >= _attackValue)
            {
                Debug.Log("折り返し");
                isIncreasing = !isIncreasing;
            }
            else if (currentValue <= _minValue)
            {
                isAttack = false;
            }
        }
        else
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
}
