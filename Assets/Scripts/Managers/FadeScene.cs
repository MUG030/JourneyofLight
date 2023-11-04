using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using Cysharp.Threading.Tasks;

public class FadeScene : MonoBehaviour
{
    public Ease EaseTime;
    public float duration = 3.0f;
    public float startAlpha = 1.0f;
    public float endAlpha = 0.0f;

    [SerializeField] private CanvasGroup _cg;

    // シーン名を管理するリスト
    public List<string> SceneNames;
    private int currentIndex = 0;
    private List<string> calledScenes = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        _cg.alpha = startAlpha;
        _cg = GetComponent<CanvasGroup>();
    }

    public async void FadeSystem()
    {
        if (gameObject.activeSelf)
        {
            await FadeIn();
        }
        else
        {
            await FadeOut();
        }
    }

    public async UniTask FadeIn()
    {
        Debug.Log("アクティブ");
        _cg.DOFade(endAlpha, duration).SetEase(EaseTime);
        await UniTask.Delay(TimeSpan.FromSeconds(duration));
        gameObject.SetActive(!gameObject.activeSelf);
    }

    public async UniTask FadeOut()
    {
        Debug.Log("非アクティブ");
        gameObject.SetActive(!gameObject.activeSelf);
        _cg.DOFade(startAlpha, duration).SetEase(EaseTime);
        await UniTask.Delay(TimeSpan.FromSeconds(duration));

        // シーンを変更
        if (currentIndex < SceneNames.Count)
        {
            string nextScene = SceneNames[currentIndex];
            if (!calledScenes.Contains(nextScene))
            {
                calledScenes.Add(nextScene);

                // シーンを非同期にロード
                async UniTask LoadSceneAsync()
                {
                    await SceneManager.LoadSceneAsync(nextScene);
                    // フェードインを開始
                    await FadeIn();
                }

                LoadSceneAsync().Forget();
                currentIndex++;
            }
        }
    }
}