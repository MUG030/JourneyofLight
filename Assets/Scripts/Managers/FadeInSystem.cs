using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cysharp.Threading.Tasks;
using System;

public class FadeInSystem : MonoBehaviour
{
    public Ease EaseTime;
    public float duration = 3.0f;
    public float startAlpha = 1.0f;
    public float endAlpha = 0.0f;

    [SerializeField] private CanvasGroup _cg;

    // Start is called before the first frame update
    async void Start()
    {
        _cg = GetComponent<CanvasGroup>();
        await FadeIn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public async UniTask FadeIn()
    {
        Debug.Log("アクティブ");
        //Time.timeScale = 0;
        _cg.DOFade(endAlpha, duration).SetEase(EaseTime);
        await UniTask.Delay(TimeSpan.FromSeconds(duration));
        Time.timeScale = 1;
        gameObject.SetActive(!gameObject.activeSelf);
    }

}
