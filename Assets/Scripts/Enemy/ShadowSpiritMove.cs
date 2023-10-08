using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowSpiritMove : MonoBehaviour
{
    public GameObject target;
    public ShadowSpiritAttack shadowSpiritAttack;

    void Update()
    {
        if (shadowSpiritAttack.shadowAtk) return;

        float targetX = target.transform.position.x;

        // Vector2.MoveTowardsではVector2型の引数を受け取るため、x座標を取得したfloatをVector2に変換して使用します。
        Vector2 targetPosition = new Vector2(targetX, transform.position.y);

        float moveSpeed = 0.5f; // 移動速度
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }
}
