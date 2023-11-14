using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class WorldLight : MonoBehaviour
{
    public Light2D light2D;
    [SerializeField] private List<Color> changeColors;
    [SerializeField] private List<int> deadEnemies;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < deadEnemies.Count; i++)
        {
            if (EnemyHP.deadEnemyCount == deadEnemies[i])
            {
                light2D.color = changeColors[i];
                break;
            }
        }
    }
}
