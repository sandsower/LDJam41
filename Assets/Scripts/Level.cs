using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {

    public GameObject[] points;

    public Player player;

	// Use this for initialization
	void Start () {
        
        int totalEnemiesToSpawn = 12;

        while (totalEnemiesToSpawn > 0) {

            SpawnPoint spawnPoint = points[Random.Range(0, points.Length)].GetComponent<SpawnPoint>();
            spawnPoint.SpawnEnemies(1, player);

            totalEnemiesToSpawn -= 1;
        }
    }
	
	// Update is called once per frame
	void Update () {

	}
}
