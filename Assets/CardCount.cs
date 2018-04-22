using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardCount : MonoBehaviour {

    public TextEngine textEngine;
    public CardHolder cardHolder;

	// Use this for initialization
	void Start () {
        cardHolder.deck.onCardPlayed += OnCardPlayed;
        cardHolder.deck.onDeckConstructed += OnDeckConstructed;
    }

    private void OnDeckConstructed()
    {
        textEngine.DrawText(GenerateTextToDisplay().ToArray());
    }

    private void OnCardPlayed(Card cardPlayed)
    {
        textEngine.DrawText(GenerateTextToDisplay().ToArray());
    }

    Queue<AvailableTextType> GenerateTextToDisplay()
    {
        Deck deck = cardHolder.deck;

        int remainingCards = deck.GetCurrentDeckSize() + deck.hand.Count;
        Queue<AvailableTextType> text = new Queue<AvailableTextType>(textEngine.ConvertNumberToText(remainingCards, 2));

        text.Enqueue(AvailableTextType.Space);
        text.Enqueue(AvailableTextType.Slash);
        text.Enqueue(AvailableTextType.Space);

        int totalCards = remainingCards + deck.GetDiscardSize();
        AvailableTextType[] totalCardCount = textEngine.ConvertNumberToText(totalCards, 2).ToArray();

        for (int i = 0; i < totalCardCount.Length; i++)
        {
            AvailableTextType character = totalCardCount[i];
            text.Enqueue(character);
        }

        return text;
    }
	
	void Update () {

	}
}
