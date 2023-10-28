using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    public GameObject bulletPrefab;
    // インスペクターから設定するランダムな色のリスト
    public List<Color> randomColors = new List<Color>();

    public float minForceX = -1f; // X軸の最小力
    public float maxForceX = 1f; // X軸の最大力
    public float minForceY = 5f; // Y軸の最小力
    public float maxForceY = 10f; // Y軸の最大力;
    public float minScale = 0.1f;
    public float maxScale = 1.0f;

    public void GenerateBullet(Vector3 slfPos)
    {
        float randomPowerX = Random.Range(minForceX, maxForceX);
        float randomPowerY = Random.Range(minForceY, maxForceY);
        // 新しいアイテムの生成位置を計算する
        Vector3 spawnPosition = new Vector3(slfPos.x, slfPos.y, slfPos.z);
        // アイテムを指定した位置に生成
        GameObject newItem = Instantiate(bulletPrefab, spawnPosition, Quaternion.identity);
        // ランダムな色を選択
        if (randomColors.Count > 0)
        {
            int randomColorIndex = Random.Range(0, randomColors.Count);

            // アイテムのSpriteRendererコンポーネントを取得
            SpriteRenderer itemRenderer = newItem.GetComponent<SpriteRenderer>();

            // ランダムな色を設定
            if (itemRenderer != null)
            {
                itemRenderer.color = randomColors[randomColorIndex];
            }
        }

        // 新しいアイテムに力を与える
        Rigidbody2D itemRb = newItem.GetComponent<Rigidbody2D>();
        if (itemRb != null)
        {
            itemRb.AddForce(new Vector2(randomPowerX, randomPowerY), ForceMode2D.Impulse);
        }

        // オブジェクトの大きさをランダムに変える
        float randomScale = Random.Range(minScale, maxScale); // minScaleとmaxScaleは適切な値に設定してください
        newItem.transform.localScale = new Vector3(randomScale, randomScale, 1.0f);
    }

}
