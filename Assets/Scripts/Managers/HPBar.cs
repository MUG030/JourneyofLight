using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    //最大HPと現在のHP。
    int maxHp = 155;
    float currentHp;
    public Slider slider;
    private bool _isUmbrellaOpen = false; // 傘が開いているかどうかのフラグ

    void Start()
    {
        slider.value = 1;
        currentHp = maxHp;
        // 5秒ごとにDamageメソッドを呼び出す
        InvokeRepeating("CallDamage", 0f, 1f);
    }

    private void CallDamage()
    {
        if (!_isUmbrellaOpen)
        {
            Damage(0.1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // シフトキーを押したら傘を切り替える
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _isUmbrellaOpen = !_isUmbrellaOpen;
        }
    }

    public void Damage(float damage)
    {
        currentHp = currentHp - damage;
        if (currentHp <= 0)
        {
            currentHp = 0;
        }

        slider.value = (float)currentHp / (float)maxHp;
        Debug.Log("slider.value : " + slider.value);
    }

    public void Recovery(int recovery)
    {
        currentHp = currentHp + recovery;
        if (currentHp >= maxHp)
        {
            currentHp = maxHp;
        }

        slider.value = (float)currentHp / (float)maxHp;
        Debug.Log("slider.value : " + slider.value);
    }
}
