using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour {

    public int rarity;

    public CardType cardType;
    public CardHolder holder;
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")) {
            Debug.Log("Picking up!");
            holder.deck.AddToDiscard(cardType);

            Destroy(gameObject);
        }
    }
}
