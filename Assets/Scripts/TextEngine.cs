using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum AvailableTextType { Zero, One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Slash, S, C, O, R, E, Space}

// Yes, this is horrible but it'll do for now

public class TextEngine : MonoBehaviour {

    RectTransform rectTransform;

    // Use this for initialization
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public Image characterTemplate;
    public Sprite[] textSprites;

    public void DrawText(AvailableTextType[] textToDraw)
    {
        if (textToDraw.Length > 0) { 
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }

            float posX = rectTransform.rect.width / textToDraw.Length;
        
            for (int i = 0; i < textToDraw.Length; i++)
            {
                AvailableTextType character = textToDraw[i];

                Debug.Log(character);

                Image characterImage = Instantiate(characterTemplate, transform);

                characterImage.sprite = textSprites[(int)character];
                characterImage.rectTransform.localPosition = new Vector3(posX * i - (rectTransform.rect.width / 2) + (characterImage.rectTransform.rect.width / 2), 0, 0);


                if (character == AvailableTextType.Space)
                {
                    characterImage.gameObject.SetActive(false);
                }
            }
        }
    }

    public Queue<AvailableTextType> ConvertNumberToText (int number, int digits)
    {
        Queue<AvailableTextType> text = new Queue<AvailableTextType>();
        
        if(digits >= 4) {
            int thousands = number / 1000;
            text.Enqueue((AvailableTextType) thousands);
            number -= thousands * 1000;
        }

        if (digits >= 3)
        {
            int hundreds = number / 1000;
            text.Enqueue((AvailableTextType)hundreds);
            number -= hundreds * 100;
        }

        if (digits >= 2)
        {
            int tens = number / 10;
            text.Enqueue((AvailableTextType)tens);
            number -= tens * 10;
        }

        text.Enqueue((AvailableTextType)number);
        return text;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
