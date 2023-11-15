using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMBase : MonoBehaviour
{
    [SerializeField]
    private AudioClip _clip;

    void Start()
    {
        // SoundManagerをFindで検索して取得
        SoundManager _soundManager = GameObject.FindObjectOfType<SoundManager>();

        if (_clip != null)
        {
            Debug.Log("音を鳴らす");
            _soundManager.PlayBgm(_clip);
        }
    }
}
