using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public HPBar hpBar;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        var recoverytarget = col.GetComponent<IRecoverable>();
        var enemytarget = col.GetComponent<IDamageable>();
        if (recoverytarget != null)
        {
            int RecoveryNum = recoverytarget.AddRecovery();
            hpBar.Recovery(RecoveryNum);
        } else if (enemytarget != null)
        {
            float DamageNum = enemytarget.AddDamage();
            hpBar.Damage(DamageNum);
        }
    }
}
