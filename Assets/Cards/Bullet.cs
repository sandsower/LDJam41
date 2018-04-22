using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IProjectile {

    public int GetDamage()
    {
        return 1;
    }

    public bool ShouldBeDestroyed()
    {
        return true;
    }

    public void ShakeCamera(CameraShaker cs) {
        cs.StartShaking(1, 1);
    }

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
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
