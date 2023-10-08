using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowSpiritMove : MonoBehaviour
{
    public GameObject target;
    [SerializeField] private float moveSpeed = 0.5f;
    public ShadowSpiritAttack shadowSpiritAttack;

    void Update()
    {
        if (shadowSpiritAttack.shadowAtk) return;

        float targetX = target.transform.position.x;

        Vector2 targetPosition = new Vector2(targetX, transform.position.y);

        transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }
}
