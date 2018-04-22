using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour {

    public GameObject[] points;

    public Player player;
    public FinalScore score;

    bool canRestartLevel = false;

	// Use this for initialization
	void Start () {
        
        int totalEnemiesToSpawn = 12;

        while (totalEnemiesToSpawn > 0) {

            SpawnPoint spawnPoint = points[Random.Range(0, points.Length)].GetComponent<SpawnPoint>();
            spawnPoint.SpawnEnemies(1, player);

            totalEnemiesToSpawn -= 1;
        }

        score.onScoreShown += OnScoreShown;
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
}
