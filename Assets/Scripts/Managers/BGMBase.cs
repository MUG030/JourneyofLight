using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMBase : MonoBehaviour
{
    [SerializeField]
    private SoundManager _soundManager;
    [SerializeField]
    private AudioClip _clip;

    void Start()
    {
        if (_clip != null)
        {
            Debug.Log("test");
            _soundManager.PlayBgm(_clip);
        }
    }
}
