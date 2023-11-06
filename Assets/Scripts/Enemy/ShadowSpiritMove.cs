using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowSpiritMove : MonoBehaviour
{
    private Camera mainCamera;
    public GameObject target;
    [SerializeField] private float moveSpeed = 0.5f;
    public ShadowSpiritAttack shadowSpiritAttack;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (shadowSpiritAttack.shadowAtk) return;

        Vector3 screenPos = mainCamera.WorldToViewportPoint(transform.position);

        if (screenPos.x >= 0 && screenPos.x <= 1 && screenPos.y >= 0 && screenPos.y <= 1)
        {
            float targetX = target.transform.position.x;

            Vector2 targetPosition = new Vector2(targetX, transform.position.y);

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }
}
