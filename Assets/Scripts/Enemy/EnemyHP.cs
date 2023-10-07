using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    //最大HPと現在のHP。
    [SerializeField] private int maxHp = 155;
    float currentHp;

    // Start is called before the first frame update
    void Start()
    {
        currentHp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(float damage)
    {
        currentHp = currentHp - damage;
        Debug.Log(currentHp);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        var attacktarget = col.GetComponent<IDamageable>();
        if (attacktarget != null)
        {
            float DamageNum = attacktarget.AddDamage();
            Damage(DamageNum);
        }
    }
}
