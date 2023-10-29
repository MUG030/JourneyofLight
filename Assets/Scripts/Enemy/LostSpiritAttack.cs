using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LostSpiritAttack : MonoBehaviour
{
    public Animator animator;
    public LostSpiritAnimation lostSpiritAnimation; 

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // アニメーション終了時に呼び出される関数
    public void OnAnimationEnd()
    {
        // アニメーションが終了したらGameObjectを非アクティブにする
        gameObject.SetActive(false);
        lostSpiritAnimation.AttackAnimationStop();
    }
}
