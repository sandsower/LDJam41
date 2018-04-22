using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(List<GameObject>))]
public class Level : MonoBehaviour {

    List<GameObject> spawnPoints;

    public Player player;

	// Use this for initialization
	void Start () {
        foreach(Transform child in transform)
        {
            if (child.CompareTag("SpawnRegion"))
            {
                SpawnPoint spawnPoint = child.GetComponent<SpawnPoint>();
                spawnPoint.SpawnEnemies(3, player);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {

	}
}
