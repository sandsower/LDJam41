using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardHolder : MonoBehaviour {

    public Deck deck;

    RectTransform rectTransform;
    public CardImage[] availableCards;
    public Image shuffleAnimation;

    public GameObject rotationPoint;

	// Use this for initialization
	void Start () {
        rectTransform = GetComponent<RectTransform>();

        deck.onHandRefilled += OnHandRefilled;
        deck.onCardPlayed += OnCardPlayed;
        deck.onStartReshuffling += OnStartReshuffling;
        deck.onFinishReshuffling += OnFinishReshuffling;
    }

    private void OnFinishReshuffling()
    {
        Clear();
    }

    private void OnStartReshuffling()
    {
        DrawShuffleAnimation();
    }

    private void OnCardPlayed(Card cardPlayed)
    {
        DrawCards(deck.hand.ToArray());
    }

    private void OnHandRefilled()
    {
        DrawCards(deck.hand.ToArray());
    }

    void DrawCards(Card[] cardsToDraw)
    {
        Clear();

        //float posY = rectTransform.rect.height / 2;
        for (int i = 0; i < cardsToDraw.Length; i++)
        {
            Image card = Instantiate(availableCards[(int) cardsToDraw[i].type].GetCardImage(i == 0), transform);
            
            float posX = (i - (cardsToDraw.Length / 2f)) * ((card.rectTransform.rect.width / 3f) + .2f);
            card.rectTransform.localPosition = new Vector3(posX, 0, 0); //  - (rectTransform.rect.width / 2) + (card.rectTransform.rect.width / 2)

            Vector3 vectorToTarget = rotationPoint.transform.position - card.rectTransform.position;
            float angle = (Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg) - 90;

            Quaternion q = Quaternion.AngleAxis(angle, Vector3.back);
            card.rectTransform.rotation = q;

            Debug.Log(card.rectTransform.rotation);
        }
    }

    void DrawShuffleAnimation()
    {
        Clear();

        Image anim = Instantiate(shuffleAnimation, transform);
        anim.rectTransform.localPosition = new Vector3(0, 0, 0);
    }

    void Clear()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
}
