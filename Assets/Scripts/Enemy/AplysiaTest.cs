using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AplysiaTest : MonoBehaviour
{
    public float delayTime = 3.0f;          //遅延時間
    public float length = 8.0f;             //範囲
    public int minGenerate = 1;
    public int maxGenerate = 3;

    GameObject player;                      //プレイヤー
    float passedTimes = 0;                  //経過時間

    public BulletEnemy bulletEnemy;

    //距離チェック
    bool CheckLength(Vector2 targetPos)
    {
        bool ret = false;
        float d = Vector2.Distance(transform.position, targetPos);
        if (length >= d)
        {
            ret = true;
        }
        return ret;

    }

    // Start is called before the first frame update
    void Start()
    {
        //プレイヤーを取得
        player = GameObject.FindGameObjectWithTag("Player");

    }
    // Update is called once per frame
    void Update()
    {
        //待機時間加算
        passedTimes += Time.deltaTime;
        //Playerとの距離チェック
        if (CheckLength(player.transform.position))
        {
            //待機時間経過
            if (passedTimes > delayTime)
            {
                passedTimes = 0;        //時間を0にリセット

                SpawnBullet();
            }
        }
    }
    //範囲表示
    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, length);
    }

    private void SpawnBullet()
    {
        // 自身のTransformコンポーネントを取得
        Transform myTransform = transform;
        // 自身の座標を取得
        Vector3 myPosition = myTransform.position;
        int bulletCount = Random.Range(minGenerate, maxGenerate);
        for (int i = 0; i < bulletCount; i++)
        {
            bulletEnemy.GenerateBullet(myPosition);
        }
    }
}
