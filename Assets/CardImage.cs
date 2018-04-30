using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardImage : MonoBehaviour {

    public Sprite cardSprite;
    public Sprite selectedCardSprite;

    public Image GetCardImage(bool selected)
    {
        Image cardImage = gameObject.GetComponent<Image>();
        if (cardImage == null)
        {
            cardImage = gameObject.AddComponent<Image>();
        }
        cardImage.sprite = selected ? selectedCardSprite : cardSprite;
        return cardImage;
    }
}
