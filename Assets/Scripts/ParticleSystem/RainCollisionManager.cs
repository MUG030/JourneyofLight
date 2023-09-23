using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainCollisionManager : MonoBehaviour
{
    private void Start()
    {
        Debug.Log("Test開始");
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Ramp"))
        {
            Debug.Log("雨に濡れた");
        }
    }
}
