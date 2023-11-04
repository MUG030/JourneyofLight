using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cysharp.Threading.Tasks;
using System;
using UnityEngine.SceneManagement;

public class FadeOutSystem : MonoBehaviour
{

    public Ease EaseTime;
    public float duration = 3.0f;
    public float startAlpha = 1.0f;
    public float endAlpha = 0.0f;

    [SerializeField] private CanvasGroup _cg;
    [SerializeField] private string _sceneName;

    public async void ChangeSystem()
    {
        await FadeOut();
    }

    public async UniTask FadeOut()
    {
        Debug.Log("非アクティブ");
        gameObject.SetActive(!gameObject.activeSelf);
        _cg.DOFade(startAlpha, duration).SetEase(EaseTime);
        await UniTask.Delay(TimeSpan.FromSeconds(duration));
        SceneManager.LoadScene(_sceneName);
    }
}
