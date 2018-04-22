using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardHolder : MonoBehaviour {

    public Deck deck;

    RectTransform rectTransform;
    public Image[] availableCards;

	// Use this for initialization
	void Start () {
        rectTransform = GetComponent<RectTransform>();

        deck.onHandRefilled += OnHandRefilled;
        deck.onCardPlayed += OnCardPlayed;
    }

    private void OnCardPlayed(Card cardPlayed)
    {
        DrawCards(deck.hand.ToArray());
    }

    private void OnHandRefilled()
    {
        DrawCards(deck.hand.ToArray());
    }

    // Update is called once per frame
    void Update () {
		
	}

    void DrawCards(Card[] cardsToDraw)
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        float posX = rectTransform.rect.width / cardsToDraw.Length;
        //float posY = rectTransform.rect.height / 2;
        for (int i = 0; i < cardsToDraw.Length; i++)
        {
            Image card = Instantiate(availableCards[(int) cardsToDraw[i].type], transform);
            card.rectTransform.localPosition = new Vector3(posX * i - (rectTransform.rect.width / 2) + (card.rectTransform.rect.width / 2) , 0, 0);
        }
    }
}
