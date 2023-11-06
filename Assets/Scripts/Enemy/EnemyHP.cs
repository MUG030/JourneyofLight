using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    //最大HPと現在のHP。
    [SerializeField] private int maxHp = 155;
    float currentHp;
    public float knockBackPower;
    //public GameObject enemyParticle;

    private Rigidbody2D rb;

    public bool isDamage = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDamage)
        {
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    public async void EnemyDamage(float damage)
    {
        currentHp = currentHp - damage;
        if (currentHp <= 0)
        {
            EnemyDead();
        }
    }

    private async void OnTriggerEnter2D(Collider2D col)
    {
        var attacktarget = col.GetComponent<IEDamageable>();
        if (attacktarget != null)
        {
            if (isDamage) return;
            float DamageNum = attacktarget.AddEDamage();
            EnemyDamage(DamageNum);

            // 自分の位置と接触してきたオブジェクトの位置とを計算して、距離と方向を出して正規化(速度ベクトルを算出)
            Vector2 distination = (transform.position - col.transform.position).normalized;
            KnockBack(distination);
            await DamageJudge();
        }
    }

    public void KnockBack(Vector2 direction)
    {
        if (0f > direction.x)
        {
            direction.x = -1.0f;
        }
        else if (0f < direction.x)
        {
            direction.x = 1.0f;
        }
        rb.velocity = Vector2.zero;
        // x軸に沿ったノックバックを実行する
        Vector2 knockbackForce = new Vector2(direction.x * knockBackPower, 5f);

        Debug.Log(knockbackForce);

        // ノックバック力を適用
        rb.velocity = knockbackForce;
    }

    public async UniTask DamageJudge()
    {
        isDamage = !isDamage;
        await UniTask.Delay(TimeSpan.FromSeconds(1.5));
        isDamage = !isDamage;
    }

    private void EnemyDead()
    {
        Destroy(gameObject);
    }
}
