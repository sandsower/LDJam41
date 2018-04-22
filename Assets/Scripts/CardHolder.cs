using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardHolder : MonoBehaviour {

    RectTransform rectTransform;
    public Image[] availableCards;

	// Use this for initialization
	void Start () {
        rectTransform = GetComponent<RectTransform>();

        int[] cardsToDraw = new int[5];
        cardsToDraw[0] = 0;
        cardsToDraw[1] = 0;
        cardsToDraw[2] = 1;
        cardsToDraw[3] = 2;
        cardsToDraw[4] = 0;

        DrawCards(cardsToDraw);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void DrawCards(int[] cardsToDraw)
    {
        float posX = rectTransform.rect.width / cardsToDraw.Length;
        //float posY = rectTransform.rect.height / 2;
        for (int i = 0; i < cardsToDraw.Length; i++)
        {
            Image card = Instantiate(availableCards[cardsToDraw[i]], transform);
            card.rectTransform.localPosition = new Vector3(posX * i - (rectTransform.rect.width / 2) + (card.rectTransform.rect.width / 2) , 0, 0);

            Debug.Log(card.rectTransform.position);
        }
    }
}
