using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    //最大HPと現在のHP。
    [SerializeField] private int maxHp = 150;
    private float currentHp;
    public Slider slider;
    private bool _isUmbrellaOpen = false; // 傘が開いているかどうかのフラグ
    private bool _damageSprite1 = false;
    private bool _damageSprite2 = false;

    [SerializeField] private GameObject _playerObject;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        slider.value = 1;
        currentHp = maxHp;
        // 5秒ごとにDamageメソッドを呼び出す
        InvokeRepeating("CallDamage", 0f, 1f);

        if (_playerObject != null)
        {
            spriteRenderer = _playerObject.GetComponent<SpriteRenderer>();
        }
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
        if (Input.GetKeyDown(KeyCode.K))
        {
            Damage(5.0f);
        }

        if (_damageSprite1)
        {
            //spriteRenderer.color = new Color(0.5f, 0.5f, 0.5f);
        }
        else if (_damageSprite2)
        {
            //spriteRenderer.color = new Color(0.3f, 0.3f, 0.3f);
        }
        //else
        //{
        //    spriteRenderer.color = Color.white;
        //}
    }

    public void Damage(float damage)
    {
        currentHp = currentHp - damage;
        if (currentHp <= 0)
        {
            currentHp = 0;
            Dead();
        }

        float switchHP = currentHp / maxHp;
        if (switchHP >= 0.7f)
        {
            Debug.Log("7割超え");
        }else if (switchHP >= 0.5f && switchHP < 0.7f)
        {
            Debug.Log("5割超え");
            _damageSprite1 = true;
            _damageSprite2 = false;
        } else if (switchHP >= 0.3f && switchHP < 0.5f)
        {
            Debug.Log("3割超え");
            _damageSprite1 = false;
            _damageSprite2 = true;
        }

        slider.value = currentHp / (float)maxHp;
    }

    public void Recovery(int recovery)
    {
        currentHp = currentHp + recovery;
        if (currentHp >= maxHp)
        {
            currentHp = maxHp;
        }

        slider.value = currentHp / (float)maxHp;
    }

    public void Dead()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
