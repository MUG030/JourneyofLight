using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System;

public class PlayerCollision : MonoBehaviour
{
    public HPBar hpBar;
    public PlayerMoveController playerMoveController;

    private Rigidbody2D rb;
    public bool isDamage = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private async void OnTriggerEnter2D(Collider2D col)
    {
        var recoverytarget = col.GetComponent<IRecoverable>();
        var enemytarget = col.GetComponent<IDamageable>();
        if (recoverytarget != null)
        {
            int RecoveryNum = recoverytarget.AddRecovery();
            hpBar.Recovery(RecoveryNum);
        } else if (enemytarget != null)
        {
            if (isDamage || Light.attackCommand) return;
            float DamageNum = enemytarget.AddDamage();
            hpBar.Damage(DamageNum);

            // 自分の位置と接触してきたオブジェクトの位置とを計算して、距離と方向を出して正規化(速度ベクトルを算出)
            Vector2 distination = (transform.position - col.transform.position).normalized;
            playerMoveController.KnockBack(distination);
            await DamageJudge();
        }
    }

    public async UniTask DamageJudge()
    {
        isDamage = !isDamage;
        await UniTask.Delay(TimeSpan.FromSeconds(1.5));
        isDamage = !isDamage;
    }
}
