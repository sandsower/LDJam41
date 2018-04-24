using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour {

    public GameObject[] points;

    public Player player;
    public FinalScore score;

    public WaveGenerator generator;

    public delegate void OnScoreChange(int score);
    public event OnScoreChange onScoreChange;

    public int currentScore = 0;
    public int enemiesToKill = 0;

    int currentWave = 0;

    bool canRestartLevel = false;

	// Use this for initialization
	void Start () {
        StartCoroutine(AdvanceWave());
        
        score.onScoreShown += OnScoreShown;
        player.onPlayerDeath += CalculateScore;
    }

    private void CalculateScore()
    {
        Deck deck = player.cardHolder.deck;
        currentScore += deck.GetScore();

        score.scoreToDraw = currentScore;
    }

    private void OnScoreShown()
    {
        canRestartLevel = true;
    }

    // Update is called once per frame
    void Update () {
        if(canRestartLevel)
        {
            if (Input.anyKey)
            {
                Debug.Log("Loading level!");
                SceneManager.LoadScene("Main");
            }
        }
	}

    IEnumerator AdvanceWave()
    {
        currentWave += 1;

        yield return new WaitForSeconds(3);

        enemiesToKill = generator.Generate(currentWave, player, points);

        if (onScoreChange != null)
        {
            onScoreChange(currentScore);
        }
    }

    public void EnemyKilled(int scoreValue)
    {
        currentScore += scoreValue;
        enemiesToKill -= 1;

        if (onScoreChange != null)
        {
            onScoreChange(currentScore);
        }

        if(enemiesToKill == 0)
        {
            StartCoroutine(AdvanceWave());
        }
    }
}
