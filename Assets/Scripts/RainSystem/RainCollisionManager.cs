using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainCollisionManager : MonoBehaviour
{
    private void Start()
    {
        Debug.Log("Test�J�n");
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Ramp"))
        {
            Debug.Log("�J�ɔG�ꂽ");
        }
    }
}
