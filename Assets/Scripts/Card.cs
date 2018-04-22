using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CardType { Blank, Normal, Super };

public class Card : MonoBehaviour {

    public Bullet bullet;
    public Blank blank;
    public Super super;

    public CardType type;

    public Card(CardType cardType)
    {
        type = cardType;
    }

    public IProjectile GetProjectileType ()
    {
        switch (type)
        {
            case CardType.Normal:
                return bullet;

            case CardType.Blank:
                return blank;

            case CardType.Super:
                return blank;

            default:
                return blank;
        }
    }
}
