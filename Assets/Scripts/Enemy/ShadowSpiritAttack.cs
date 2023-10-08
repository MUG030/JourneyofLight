using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class ShadowSpiritAttack : MonoBehaviour
{
    [SerializeField] private GameObject shadowAttack;
    public bool shadowAtk = false;

    private async void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            shadowAttack.SetActive(true);
            await OffActive();
        }
    }

    private async UniTask OffActive()
    {
        shadowAtk = true;
        await UniTask.Delay(TimeSpan.FromSeconds(0.5));
        shadowAttack.SetActive(false);
        shadowAtk = false;
    }
}
