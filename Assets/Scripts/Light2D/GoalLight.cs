using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class GoalLight : MonoBehaviour
{
    public Light2D light2D;
    [SerializeField] private float _animationSpeed = 1f;
    [SerializeField] private float _minValue = 0f;
    [SerializeField] private float _maxValue = 1f;
    [SerializeField] private int _clearCount = 0;
    [SerializeField] private Color targetColor;
    public FadeOutSystem fadeOutSystem;

    private float currentValue;
    private bool isIncreasing = true;
    private bool changeScene = false;

    internal Color color;

    // Start is called before the first frame update
    void Start()
    {
        currentValue = _minValue;
    }

    // Update is called once per frame
    private async void Update()
    {
        if (EnemyHP.deadEnemyCount >= _clearCount)
        {
            light2D.color = targetColor;
            if (changeScene && Input.GetKeyDown(KeyCode.Return))
            {
                await fadeOutSystem.FadeOut();
            }
        }

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            changeScene = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            changeScene = false;
        }
    }

}
