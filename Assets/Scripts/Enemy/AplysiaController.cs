using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aplysia : MonoBehaviour
{
    public GameObject objPrefab;            //発生させるPrefabデータ
    public float delayTime = 3.0f;          //遅延時間
    public float fireSpeed = 4.0f;          //発射速度
    public float length = 8.0f;             //範囲

    GameObject player;                      //プレイヤー
    Transform gateTransform;                //発射口のTransform
    float passedTimes = 0;                  //経過時間

    public float minForceX = -1f; // X軸の最小力
    public float maxForceX = 1f; // X軸の最大力
    public float minForceY = 5f; // Y軸の最小力
    public float maxForceY = 10f; // Y軸の最大力;

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
        //発射口オブジェクトのTransformを取得
        gateTransform = transform.Find("gate");
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
                Debug.Log("test");
                passedTimes = 0;        //時間を0にリセット
                //砲弾をプレハブから作る
                Vector2 pos = new Vector2(gateTransform.position.x,
                    gateTransform.position.y);
                GameObject Bullet= Instantiate(objPrefab, pos, Quaternion.identity);
                //砲身が向いている方向に発射する
                Rigidbody2D rbody = Bullet.GetComponent<Rigidbody2D>();
                float angleZ = transform.localEulerAngles.z;
                float x = Mathf.Cos(angleZ * Mathf.Deg2Rad);
                float y = Mathf.Sin(angleZ * Mathf.Deg2Rad);
                Vector2 v = new Vector2(x, y) * fireSpeed;
                rbody.AddForce( v, ForceMode2D.Impulse);
            }
        }
    }
    //範囲表示
    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, length);
    }
}