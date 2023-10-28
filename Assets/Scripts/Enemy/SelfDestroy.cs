using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    public float destroyThresholdY = -10f; // 自身を削除するy軸の閾値

    void Update()
    {
        // ゲームオブジェクトの現在の位置のy座標をチェック
        if (transform.position.y <= destroyThresholdY)
        {
            // y軸が閾値以下になったら自身を削除
            Destroy(gameObject);
        }
    }
}

