using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobTouch : MonoBehaviour
{
    [SerializeField] private GameObject guidObject;
    bool moblost = false;
    public CollectItemManager collectItemManager;

    private void Start()
    {
        guidObject.SetActive(false);
        
    }

    private void Update()
    {
        if (moblost && Input.GetKeyDown(KeyCode.Z))
        {
            SpawnItem();
        }
    }

    private void SpawnItem()
    {
        // 自身のTransformコンポーネントを取得
        Transform myTransform = transform;

        // 自身の座標を取得
        Vector3 myPosition = myTransform.position;

        Debug.Log("いつでもお前を浄化できるんだよぉ");
        Destroy(gameObject);
        int itemCount = Random.Range(2, 8); // 2~8個のランダムな数
        Debug.Log(itemCount);
        for (int i = 0; i < itemCount; i++)
        {
            collectItemManager.SpawnRandomItem(myPosition);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            guidObject.SetActive(true);
            moblost = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            guidObject.SetActive(false);
            moblost = false;
        }
    }
}
