using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    //最大HPと現在のHP。
    int maxHp = 155;
    int currentHp;
    public Slider slider;

    void Start()
    {
        slider.value = 1;
        currentHp = maxHp;
        Debug.Log("Start currentHp : " + currentHp);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Damage(10);
        } else if (Input.GetKeyDown(KeyCode.J))
        {
            Recovery(10);
        }
    }

    public void Damage(int damage)
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
