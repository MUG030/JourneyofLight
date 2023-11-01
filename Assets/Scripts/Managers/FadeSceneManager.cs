using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeSceneManager : DontDestroySingletonMonoBehaviour<FadeSceneManager>
{
    private const float FADE_DURATION = 0.5f;
    [SerializeField]
    private Image image;
    private CanvasGroup canvasGroup;

    protected override void Awake()
    {
        base.Awake();
        canvasGroup = image.GetComponent<CanvasGroup>();
    }

    public void LoadWithFade(string sceneName)
    {
        image.raycastTarget = true;
        var process = SceneManager.LoadSceneAsync(sceneName);
        process.allowSceneActivation = false;
        process.AsObservable().Where(p => p.isDone).Subscribe(p =>
        {
            canvasGroup.DOFade(0f, FADE_DURATION);
        });

        canvasGroup.DOFade(1f, FADE_DURATION).OnComplete(() =>
        {
            while (process.progress < 0.9f) { /* 何か処理があれば */ }
            process.allowSceneActivation = true;
            image.raycastTarget = false;
        });
    }
}