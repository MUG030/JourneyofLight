﻿using UnityEngine;

public class ParticleController : MonoBehaviour
{
    private int count;

    private void Start()
    {
        count = 0;
    }

    private void Update()
    {
    }

    void OnParticleCollision(GameObject obj)
    {
        Count++;
    }

    public int Count
    {
        get { return count; }
        private set { count = value; }
    }
}
