using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class TypeWriteEffect : MonoBehaviour
{
    public TMP_Text textMeshPro;
    public List<string> textList;
    public float typingSpeed = 0.1f;

    private int currentIndex = 0;
    private bool isTyping = false;

    private void Start()
    {
        // 初期文章を表示
        ShowNextText();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && !isTyping)
        {
            // Enterキーが押されたら次の文章を表示
            ShowNextText();
        }
    }

    private void ShowNextText()
    {
        if (currentIndex < textList.Count)
        {
            isTyping = true;
            string textToType = textList[currentIndex];

            // エスケープ文字 \n を実際の改行に変換
            textToType = textToType.Replace("\\n", "\n");

            // DOTweenを使ってテキストをクリアしてからタイプライター風に表示
            textMeshPro.text = "";
            DOTween.To(() => textMeshPro.text, x => textMeshPro.text = x, textToType, textToType.Length * typingSpeed)
                .SetOptions(true)
                .SetEase(Ease.Linear)
                .SetUpdate(true)
                .OnComplete(async () =>
                {
                    isTyping = false;
                    currentIndex++;

                    if (currentIndex == textList.Count)
                    {
                        Debug.Log("全ての文章が表示されました。");

                        // FadeCanvasオブジェクトをタグで検索
                        GameObject fadeCanvas = GameObject.FindWithTag("FadeCanvas");

                        if (fadeCanvas != null)
                        {
                            Debug.Log("発見した");
                            // FadeScene.csのFadeOutメソッドを呼び出す
                            FadeScene fadeScene = fadeCanvas.GetComponent<FadeScene>();
                            if (fadeScene != null)
                            {
                                await fadeScene.FadeOut();
                            }
                        }
                    }
                });
        }
        else
        {
            Debug.Log("全ての文章が表示されました。");
        }
    }
}