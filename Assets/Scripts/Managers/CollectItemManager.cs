using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItemManager : MonoBehaviour
{
    // アイテムのPrefabリスト
    public List<GameObject> itemPrefabs = new List<GameObject>();
    // アイテム生成後のPrefabリスト
    private List<CollectItem> itemList = new List<CollectItem>();

    private void Update()
    {
        // Qキーが押されたときにランダムに2~8個のアイテムを生成
        if (Input.GetKeyDown(KeyCode.Q))
        {
            int itemCount = Random.Range(2, 9); // 2~8個のランダムな数
            for (int i = 0; i < itemCount; i++)
            {
                SpawnRandomItem();
            }
        }

        // Rキーが押されたときに生成したアイテムのDrop関数を呼び出す
        if (Input.GetKeyDown(KeyCode.R))
        {
            CallDropFunctionOnItems();
        }
    }

    // アイテムが生成されるときにリストに追加
    private void SpawnRandomItem()
    {
        if (itemPrefabs.Count > 0)
        {
            int randomIndex = Random.Range(0, itemPrefabs.Count);
            GameObject newItem = Instantiate(itemPrefabs[randomIndex], transform.position, Quaternion.identity);

            // 新しいアイテムが持っているCollectItemコンポーネントを取得してリストに追加
            CollectItem collectItem = newItem.GetComponent<CollectItem>();
            if (collectItem != null)
            {
                itemList.Add(collectItem);
            }
        }
    }

    // Rキーが押されたときにリスト内のアイテムにアクセス
    private void CallDropFunctionOnItems()
    {
        foreach (CollectItem collectItem in itemList)
        {
            // Drop関数を持っている場合にのみ呼び出す
            if (collectItem != null)
            {
                collectItem.Drop();
            }
        }
    }
}
