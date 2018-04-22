using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentWaveCounter : MonoBehaviour {
    public TextEngine textEngine;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        UpdateWaveCount(1);
    }

    void UpdateWaveCount(int wave) {
        Queue<AvailableTextType> text = textEngine.ConvertNumberToText(wave, 3);
        
        textEngine.DrawText(text.ToArray());
    }
}
