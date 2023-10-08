using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shadowAtkDamage : MonoBehaviour, IDamageable
{
    public float shadowDamage = 5.0f;

    public float AddDamage()
    {
        return shadowDamage;
    }
}
