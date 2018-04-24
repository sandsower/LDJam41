using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentScoreCounter : MonoBehaviour {
    public TextEngine textEngine;

    public Level level;

    // Use this for initialization
    void Start () {
        level.onScoreChange += OnScoreChange;
	}

    private void OnScoreChange(int score)
    {
        DrawScore(score);
    }

    void DrawScore(int score)
    {
        Queue<AvailableTextType> text = new Queue<AvailableTextType>();

        text.Enqueue(AvailableTextType.S);
        text.Enqueue(AvailableTextType.C);
        text.Enqueue(AvailableTextType.O);
        text.Enqueue(AvailableTextType.R);
        text.Enqueue(AvailableTextType.E);

        text.Enqueue(AvailableTextType.Space);

        AvailableTextType[] scoreArray = textEngine.ConvertNumberToText(score, 4).ToArray();

        for (int i = 0; i < scoreArray.Length; i++)
        {
            AvailableTextType character = scoreArray[i];
            text.Enqueue(character);
        }

        textEngine.DrawText(text.ToArray());
    }
}
