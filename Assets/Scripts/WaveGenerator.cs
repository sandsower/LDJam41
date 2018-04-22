using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveGenerator : MonoBehaviour {

    public int enemyRate = 6;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public int Generate(int wave, Player player, GameObject[] points)
    {
        int totalEnemiesToSpawn = enemyRate * wave;

        while (totalEnemiesToSpawn > 0)
        {
            SpawnPoint spawnPoint = points[Random.Range(0, points.Length)].GetComponent<SpawnPoint>();
            spawnPoint.SpawnEnemies(1, player);

            totalEnemiesToSpawn -= 1;
        }

        return enemyRate * wave;
    }
}
