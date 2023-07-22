using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UmbrellaController : MonoBehaviour
{
    public float umbrellaMoveSpeedMultiplier = 0.5f; // 傘を差している間の移動速度の倍率
    public float umbrellaFallSpeedMultiplier = 0.5f; // 傘を差している間の落下速度の倍率

    private PlayerMoveController moveController; // PlayerMoveControllerスクリプトへの参照
    private Rigidbody2D rb; // プレイヤーのRigidbody2Dコンポーネント
    private bool isUmbrellaOpen = false; // 傘が開いているかどうかのフラグ

    private void Start()
    {
        moveController = GetComponent<PlayerMoveController>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // シフトキーを押したら傘を切り替える
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isUmbrellaOpen = !isUmbrellaOpen;
            UpdateUmbrellaState();
        }
    }

    private void UpdateUmbrellaState()
    {
        if (isUmbrellaOpen)
        {
            // 傘を差している間の処理
            moveController.SetMoveSpeed(umbrellaMoveSpeedMultiplier); // 移動速度を減らす
            moveController.SetGravityScale(umbrellaFallSpeedMultiplier); // 落下速度を減らす
        }
        else
        {
            // 傘を閉じている間の処理
            moveController.SetMoveSpeed(1f); // 移動速度を元に戻す
            moveController.SetGravityScale(1f); // 落下速度を元に戻す
        }
    }
}
