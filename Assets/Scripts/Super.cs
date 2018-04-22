using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Super : MonoBehaviour, IProjectile {

    public CameraShaker cs;

    public int GetDamage()
    {
        return 2;
    }

    public bool ShouldBeDestroyed()
    {
        return false;
    }

    public void ShakeCamera()
    {
        cs.StartShaking(2);
    }

    // Use this for initialization
    void Start()
    {
        cs = (CameraShaker)GetComponent<CameraShaker>();
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
        return 2f;
    }

    public float GetProjectileSpeed()
    {
        return 6f;
    }
}
