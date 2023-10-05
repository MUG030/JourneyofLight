using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItemManager : MonoBehaviour
{
    // アイテムのPrefabリスト
    public List<GameObject> itemPrefabs = new List<GameObject>();
    // アイテム生成後のPrefabリスト
    private List<CollectItem> itemList = new List<CollectItem>();
    // アイテム生成場所の指定
    [SerializeField] private GameObject _mobobject;

    // アイテムが生成されるときにリストに追加
    public void SpawnRandomItem(Vector3 selfPosition)
    {
        if (itemPrefabs.Count > 0)
        {
            int randomIndex = Random.Range(0, itemPrefabs.Count);

            // 新しいアイテムの生成位置を計算する
            Vector3 spawnPosition = new Vector3(selfPosition.x, selfPosition.y + 10, selfPosition.z);

            // アイテムを指定した位置に生成
            GameObject newItem = Instantiate(itemPrefabs[randomIndex], spawnPosition, Quaternion.identity);
        }
    }
}
