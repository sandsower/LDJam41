using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {

    public GameObject enemy;

    public Color GizmosColor = new Color(1.0f, 0.5f, 0.5f, 0.2f);

    void OnDrawGizmos()
    {
        Gizmos.color = GizmosColor;
        Gizmos.DrawCube(transform.position, transform.localScale);
    }

    public void SpawnEnemies(int numberOfEnemies, Player player)
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            SpawnEnemy(player);
        }
    }

    void SpawnEnemy(Player player)
    {
        GameObject spawned = Instantiate(enemy, transform.parent);

        spawned.GetComponent<IEnemy>().setPlayer(player);

        Vector2 initialPoint = transform.localPosition;
        Vector2 position = new Vector2(Random.Range(initialPoint.x, transform.lossyScale.x), Random.Range(initialPoint.y, transform.lossyScale.y));

        spawned.transform.localPosition = position;   
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
