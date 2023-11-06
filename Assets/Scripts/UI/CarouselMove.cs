using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarouselMove : MonoBehaviour
{
    public Button leftButton; // 左ボタン
    public Button rightButton; // 右ボタン
    public ScrollRect scrollRect; // ScrollView

    private RectTransform contentTransform; // ContentのRectTransform
    private float itemWidth; // 項目の幅
    private int currentItemIndex = 0; // 現在表示している項目のインデックス

    private void Start()
    {
        // ContentのRectTransformを取得
        contentTransform = scrollRect.content;

        // 項目の幅を計算
        GridLayoutGroup gridLayout = contentTransform.GetComponent<GridLayoutGroup>();
        itemWidth = gridLayout.cellSize.x + gridLayout.spacing.x;

        leftButton.onClick.AddListener(ScrollLeft);
        rightButton.onClick.AddListener(ScrollRight);
    }

    private void ScrollLeft()
    {
        currentItemIndex--;
        if (currentItemIndex < 0)
            currentItemIndex = 0;

        // スクロール位置を設定
        Vector2 targetPosition = new Vector2(-currentItemIndex * itemWidth, 0f);
        scrollRect.content.anchoredPosition = targetPosition;
    }

    private void ScrollRight()
    {
        currentItemIndex++;
        if (currentItemIndex >= contentTransform.childCount)
            currentItemIndex = contentTransform.childCount - 1;

        // スクロール位置を設定
        Vector2 targetPosition = new Vector2(-currentItemIndex * itemWidth, 0f);
        scrollRect.content.anchoredPosition = targetPosition;
    }

}