using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalScore : MonoBehaviour {

    public TextEngine textEngine;
    public Player player;

    public delegate void OnScoreShown();
    public event OnScoreShown onScoreShown;

    // Use this for initialization
    void Start()
    {
        player.onPlayerDeath += OnPlayerDeath;
    }

    private void OnPlayerDeath()
    {
        StartCoroutine(ShowFinalScore());
    }

    IEnumerator ShowFinalScore()
    {
        yield return new WaitForSeconds(3);

        textEngine.DrawText(GenerateTextToDisplay().ToArray());

        if (onScoreShown != null)
        {
            onScoreShown();
        }
    }

    Queue<AvailableTextType> GenerateTextToDisplay()
    {
        Queue<AvailableTextType> text = new Queue<AvailableTextType>();

        text.Enqueue(AvailableTextType.S);
        text.Enqueue(AvailableTextType.C);
        text.Enqueue(AvailableTextType.O);
        text.Enqueue(AvailableTextType.R);
        text.Enqueue(AvailableTextType.E);

        text.Enqueue(AvailableTextType.Space);


        AvailableTextType[] score = textEngine.ConvertNumberToText(2018, 4).ToArray();

        for (int i = 0; i < score.Length; i++)
        {
            AvailableTextType character = score[i];
            text.Enqueue(character);
        }

        return text;
    }
}
