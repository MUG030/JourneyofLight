using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class WorldLight : MonoBehaviour
{
    public Light2D light2D;
    [SerializeField] private Color changeColor1;
    [SerializeField] private Color changeColor2;
    [SerializeField] private int _deadEnemy1;
    [SerializeField] private int _deadEnemy2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(EnemyHP.deadEnemyCount == _deadEnemy1)
        {
            light2D.color = changeColor1;
        } else if (EnemyHP.deadEnemyCount == _deadEnemy2)
        {
            light2D.color = changeColor2;
        }
    }
}
