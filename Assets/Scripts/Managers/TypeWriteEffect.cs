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
    public FadeOutSystem fadeOutSystem;

    private int currentIndex = 0;
    private bool isTyping = false;

    private void Start()
    {
        // 初期文章を表示
        ShowNextText();
    }

    private async void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && !isTyping)
        {
            // Enterキーが押されたら次の文章を表示
            ShowNextText();
        }
        else if (Input.GetKeyDown(KeyCode.Space) && isTyping)
        {
            Debug.Log("スキップが選択された。");
            await fadeOutSystem.FadeOut();
        }
    }

    private async void ShowNextText()
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
                .OnComplete(() =>
                {
                    isTyping = false;
                    currentIndex++;

                    if (currentIndex == textList.Count)
                    {
                        Debug.Log("全ての文章が表示されました。");
                    }
                });
        }
        else
        {
            Debug.Log("次のシーンが呼ばれます");
            await fadeOutSystem.FadeOut();
        }
    }
}