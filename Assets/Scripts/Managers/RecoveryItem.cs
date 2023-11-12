using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoveryItem : MonoBehaviour, IRecoverable
{
    public int AddRecovery()
    {
        Destroy(gameObject);
        return 3;
    }
}
