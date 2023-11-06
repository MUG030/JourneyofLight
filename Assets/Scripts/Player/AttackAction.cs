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
    private bool attackSwitch = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    async void Update()
    {
        // isAttack が true になった直後に処理を開始する
        if (Light.isAttack && Light.attackCommand && attackSwitch)
        {
            Debug.Log("攻撃処理開始");
            await ActivateAttackObjectsAsync();
        }
    }

    private async UniTask ActivateAttackObjectsAsync()
    {
        attackSwitch = !attackSwitch;
        _attackObject1.SetActive(true);

        await UniTask.Delay(TimeSpan.FromSeconds(1.3));
        _attackObject2.SetActive(true);

        await UniTask.Delay(TimeSpan.FromSeconds(1.7));
        _attackObject3.SetActive(true);

        await UniTask.Delay(TimeSpan.FromSeconds(1.8));
        _attackObject3.SetActive(false);
        _attackObject2.SetActive(false);
        _attackObject1.SetActive(false);
        attackSwitch = !attackSwitch;
    }
}
