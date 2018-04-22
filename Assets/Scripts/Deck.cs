using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Deck : MonoBehaviour {

    public int normalShots = 17;
    public int superShots = 1;
    public int blanks = 2;

    public int handSize = 5;
    public Queue<Card> hand;
    public Card cardTemplate;

    Queue<Card> currentDeck;
    Queue<Card> discard;
    
    public delegate void OnCardPlayed(Card cardPlayed);
    public event OnCardPlayed onCardPlayed;

    public delegate void OnHandRefilled();
    public event OnHandRefilled onHandRefilled;

    void EnqueueCardOfType(CardType cardType)
    {
        Card card = Instantiate(cardTemplate, transform);
        card.type = cardType;
        currentDeck.Enqueue(card);
    }

    void GenerateStarterDeck() {
        currentDeck = new Queue<Card>();
        
        for (int i = 0; i < normalShots; i++)
        {
            EnqueueCardOfType(CardType.Normal);
        }

        for (int i = 0; i < superShots; i++)
        {
            EnqueueCardOfType(CardType.Super);
        }


        for (int i = 0; i < blanks; i++)
        {
            EnqueueCardOfType(CardType.Blank);
        }

        currentDeck = RandomizeCards(currentDeck);
    }

    // Use this for initialization
    void Start () {
        // Create initial deck and empty hand
        hand = new Queue<Card>();

        GenerateStarterDeck();

        RefillHand();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public Card GetNextCard() {
        // Pop from the queue, send delegate notice for possible animations
        Card card = hand.Dequeue();

        if(onCardPlayed != null)
        {
            onCardPlayed(card);
        }

        discard.Enqueue(card);

        Debug.Log(card);

        return card;
    }

    public bool IsDeckEmpty()
    {
        return currentDeck.Count == 0;
    }

    public bool IsHandEmpty()
    {
        return hand.Count == 0;
    }

    public void RefillHand()
    {
        int toDraw = handSize;
        if(currentDeck.Count < handSize)
        {
            toDraw = currentDeck.Count;
        }

        for (int i = 0; i < toDraw; i++)
        {
            Card card = currentDeck.Dequeue();
            hand.Enqueue(card);
        }

        if(onHandRefilled != null)
        {
            onHandRefilled();
        }
    }

    public void RefillDeck()
    {
        currentDeck = RandomizeCards(discard);
    }

    static Queue<Card> RandomizeCards(Queue<Card> cards)
    {
        List<Card> newCards = new List<Card>(cards);
        System.Random _random = new System.Random();

        Card tempCard;

        int n = newCards.Count;
        for (int i = 0; i < n; i++)
        {
            int r = i + (int)(_random.NextDouble() * (n - i));
            tempCard = newCards[r];
            newCards[r] = newCards[i];
            newCards[i] = tempCard;
        }

        return new Queue<Card>(newCards);
    }
}
