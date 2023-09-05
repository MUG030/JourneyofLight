using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItem : MonoBehaviour
{
    [SerializeField]
    private GameObject _playerObject = null;

    //回収開始を呼んでからすぐに動き出すのを避ける
    [SerializeField]
    private float _delayTimer = 0.5f;

    //何かしらの不具合で消えない場合に備えて回収にかかる最大の時間を設定しておく
    [SerializeField]
    private float _maxTimer = 10.0f;

    //回収の速度
    [SerializeField]
    private float _speed = 0.4f;

    //プレイヤーにどの程度近づいたら回収したことにするか
    [SerializeField]
    private float _collectDistance = 0.3f;

    private float _timer = 0.0f;
    private bool _isCollect = false;

    private void Start()
    {
        //初手は非表示にしておく
        this.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (!_isCollect)
        {
            return;
        }

        _timer += Time.deltaTime;
        if (_timer < _delayTimer)
        {
            return;
        }
        //回収の最大時間を超えていないかチェック
        else if (_timer > _maxTimer)
        {
            FinishCollect();
            return;
        }

        //プレイヤーに向かって進ませる
        transform.position = Vector3.MoveTowards(transform.position, _playerObject.transform.position, _speed);

        //特定の距離まで近づいたら回収完了
        var diff = _playerObject.transform.position - transform.position;
        if (diff.magnitude < _collectDistance)
        {
            FinishCollect();
        }
    }

    /// <summary>
    /// オブジェクトを出現させる
    /// </summary>
    public void Drop()
    {
        Debug.Log("Drop");
        //ランダムなObjectを2～4個の範囲で出現させる
        var random = Random.Range(2, 5);
        for (int i = 0; i < random; i++)
        {
            //ランダムな位置に出現させる
            var randomPosition = new Vector3(Random.Range(-1.0f, 1.0f), 0.0f, Random.Range(-1.0f, 1.0f));
            var item = Instantiate(this.gameObject, this.transform.position + randomPosition, Quaternion.identity);
            item.GetComponent<CollectItem>().Collect();
        }

        this.gameObject.SetActive(true);
    }

    /// <summary>
    /// 回収を開始する
    /// </summary>
    public void Collect()
    {
        _timer = 0.0f;
        _isCollect = true;

        //念のため見える状態にしておく
        Drop();
    }

    /// <summary>
    /// 回収を完了させる
    /// </summary>
    public void FinishCollect()
    {
        _isCollect = false;
        this.gameObject.SetActive(false);

        //もし回収完了のタイミングで処理をしたい場合はここに処理を追加する
    }
}
