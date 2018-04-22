using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShaker : MonoBehaviour {

    Vector3 originalCameraPosition;
    float shakeAmt = 0;

    public void StartShaking(float magnitude) {

        shakeAmt = magnitude * .0125f;
        InvokeRepeating("CameraShake", 0, .01f);
        Invoke("StopShaking", 0.3f);
    }

    void CameraShake()
    {
        if (shakeAmt > 0)
        {
            float quakeAmt = Random.value * shakeAmt * 2 - shakeAmt;
            Vector3 pp = Camera.main.transform.position;
            pp.y += quakeAmt; // can also add to x and/or z
            pp.x += quakeAmt;
            Camera.main.transform.position = pp;
        }
    }

    void StopShaking()
    {
        CancelInvoke("CameraShake");
        Camera.main.transform.position = originalCameraPosition;

        Debug.Log(Camera.main.transform.position);
    }

    void Start() {
        originalCameraPosition = Camera.main.transform.position;
    }
}
