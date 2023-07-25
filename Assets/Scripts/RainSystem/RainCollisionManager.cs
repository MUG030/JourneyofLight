using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainCollisionManager : MonoBehaviour
{
    private void Start()
    {
        Debug.Log("TestŠJŽn");
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Ramp"))
        {
            Debug.Log("‰J‚É”G‚ê‚½");
        }
    }
}
