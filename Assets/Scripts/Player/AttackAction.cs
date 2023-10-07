using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class AttackAction : MonoBehaviour
{
    [SerializeField] private GameObject _attackObject1;
    [SerializeField] private GameObject _attackObject2;
    [SerializeField] private GameObject _attackObject3;

    public static bool attackCommand = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    async void Update()
    {
        // isAttack が true になった直後に処理を開始する
        if (!Light2DAnimation.isAttack && Input.GetKeyDown(KeyCode.X))
        {
            await ActivateAttackObjectsAsync();
        }
    }

    private async UniTask ActivateAttackObjectsAsync()
    {
        _attackObject1.SetActive(true);

        await UniTask.Delay(TimeSpan.FromSeconds(1.3));
        _attackObject2.SetActive(true);

        await UniTask.Delay(TimeSpan.FromSeconds(1.7));
        _attackObject3.SetActive(true);

        await UniTask.Delay(TimeSpan.FromSeconds(1.8));
        _attackObject3.SetActive(false);
        _attackObject2.SetActive(false);
        _attackObject1.SetActive(false);
    }
}
