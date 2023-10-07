using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDamage : MonoBehaviour, IDamageable
{
    public float baseDamage = 5.0f;

    public float AddDamage()
    {
        return baseDamage;
    }
}
