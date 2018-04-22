using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour {

    public int rarity;

    public CardType cardType;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")) {
            CardHolder holder = GameObject.Find("CardHolder").GetComponent<CardHolder>();
            holder.deck.AddToDiscard(cardType);

            Destroy(gameObject);
        }
    }
}
