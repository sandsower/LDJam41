using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Super : MonoBehaviour, IProjectile {

    public CameraShaker cs;

    public int GetDamage()
    {
        return 1;
    }

    public bool ShouldBeDestroyed()
    {
        return true;
    }

    public void ShakeCamera()
    {
        cs.StartShaking(1);
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
}
