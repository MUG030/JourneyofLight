using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonChange : MonoBehaviour
{
    public FadeOutSystem fadeOutSystem;

    public async void Button()
    {
        await fadeOutSystem.FadeOut();
    }
}
