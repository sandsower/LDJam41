using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour, IProjectile {
    
    public int GetDamage()
    {
        return 0;
    }

    public bool ShouldBeDestroyed()
    {
        return true;
    }

    public void ShakeCamera(CameraShaker cs)
    {
        cs.StartShaking(0, 0);
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
        return .5f;
    }

    public float GetProjectileSpeed()
    {
        return 1f;
    }
}
