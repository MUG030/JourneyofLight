using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDe : MonoBehaviour
{
    // 削除する時間指定
    public float deleteTime = 3.0f; 

    // Start is called before the first frame update
    void Start()
    {
        // 削除設定
        Destroy(gameObject, deleteTime); 
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // 何かに接触したら消す
        Destroy(gameObject); 
    }
}
