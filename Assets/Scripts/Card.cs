using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CardType { Blank, Normal, Super, Score };

public class Card : MonoBehaviour {

    public Bullet bullet;
    public Blank blank;
    public Super super;
    public Score score;

    public CardType type;

    public IProjectile GetProjectile ()
    {
        switch (type)
        {
            case CardType.Normal:
                return bullet;

            case CardType.Blank:
                return blank;

            case CardType.Super:
                return super;

            case CardType.Score:
                return score;

            default:
                return blank;
        }
    }
}
