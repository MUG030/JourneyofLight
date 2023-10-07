using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItemManager : MonoBehaviour
{
    // アイテムのPrefabリスト
    public List<GameObject> itemPrefabs = new List<GameObject>();
    // インスペクターから設定するランダムな色のリスト
    public List<Color> randomColors = new List<Color>();

    // アイテムが生成されるときにリストに追加
    public void SpawnRandomItem(Vector3 selfPosition)
    {
        if (itemPrefabs.Count > 0)
        {
            int randomIndex = Random.Range(0, itemPrefabs.Count);
            Debug.Log("count");

            // 新しいアイテムの生成位置を計算する
            Vector3 spawnPosition = new Vector3(selfPosition.x, selfPosition.y + 10, selfPosition.z);

            // アイテムを指定した位置に生成
            GameObject newItem = Instantiate(itemPrefabs[randomIndex], spawnPosition, Quaternion.identity);

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
        }
    }
}
