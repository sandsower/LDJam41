using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {

    public GameObject[] enemies;
    public GameObject defaultEnemy;
    public int[] spawnRetries;

    public Color GizmosColor = new Color(1.0f, 0.5f, 0.5f, 0.2f);

    void OnDrawGizmos()
    {
        Gizmos.color = GizmosColor;
        Gizmos.DrawCube(transform.position, transform.localScale);
    }

    // Use this for initialization
    void Start()
    {
        spawnRetries = new int[enemies.Length];
    }

    GameObject GetEnemyToSpawn(int currentWave)
    {
        System.Random random = new System.Random();
        for (int i = 0; i < enemies.Length; i++)
        {
            BadGuyTemplate enemy = enemies[i].GetComponent<BadGuyTemplate>();
            double roll = random.NextDouble();

            Debug.Log("Roll " + roll);
            Debug.Log("Difficulty " + enemy.enemyDifficulty);
            Debug.Log("Retries " + spawnRetries[i]);

            Debug.Log((double)(currentWave + spawnRetries[i]) / enemy.enemyDifficulty);

            if (roll < (double)(currentWave + spawnRetries[i]) / enemy.enemyDifficulty)
            {
                spawnRetries[i] = 0;
                Debug.Log("Spawning " + enemy);
                return enemy.gameObject;
            }
            else
            {
                spawnRetries[i]++;
            }
        }

        Debug.Log("Spawning default");
        return defaultEnemy;
    }

    public void SpawnEnemy(Player player, int currentWave)
    {
        GameObject spawned = Instantiate(GetEnemyToSpawn(currentWave), transform.parent);

        spawned.GetComponent<IEnemy>().setPlayer(player);

        Vector2 initialPoint = transform.localPosition;
        spawned.transform.localPosition = initialPoint;   
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
