﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Super : MonoBehaviour, IProjectile {

    
    public int GetDamage()
    {
        return 2;
    }

    public bool ShouldBeDestroyed()
    {
        return false;
    }

    public void ShakeCamera(CameraShaker cs)
    {
        cs.StartShaking(2, 2);
    }

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public GameObject GetObjectToInstantiate()
    {
        return gameObject;
    }

    public float GetMaxTimelimit()
    {
        return 1f;
    }

    public float GetProjectileSpeed()
    {
        return 2f;
    }
}
