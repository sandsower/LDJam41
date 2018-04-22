using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentWaveCounter : MonoBehaviour {
    public TextEngine textEngine;

    public Level level;

    // Use this for initialization
    void Start () {
        level.onWaveAdvance += OnWaveAdvance;
	}

    private void OnWaveAdvance(int wave)
    {
        UpdateWaveCount(wave);
    }

    void UpdateWaveCount(int wave) {
        Queue<AvailableTextType> text = textEngine.ConvertNumberToText(wave, 3);
        
        textEngine.DrawText(text.ToArray());
    }
}
