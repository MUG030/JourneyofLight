using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoveryItem : MonoBehaviour, IRecoverable
{
    public float lifeTime = 0.01f;

    public int AddRecovery()
    {
        Destroy(gameObject, lifeTime);
        Debug.Log("回復するよ");
        return 10;
    }
}
