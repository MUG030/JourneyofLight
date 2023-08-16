using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollow : MonoBehaviour
{
    [SerializeField] private float followSpeed = 5.0f;

    private void Update()
    {
        // マウスの現在の位置を取得
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        // プレイヤーの位置をマウスの位置に近づける
        transform.position = Vector3.MoveTowards(transform.position, mousePosition, followSpeed * Time.deltaTime);
    }
}
