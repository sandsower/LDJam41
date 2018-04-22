using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour {

    public Texture2D crosshairImage;
    public Texture2D fullHeart;
    public Texture2D emptyHeart;

    // Use this for initialization
    void Start () {
        Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {

    }

    void OnGUI(){
        float xMin = Screen.width - (Screen.width - Input.mousePosition.x) - (crosshairImage.width / 2);
        float yMin = (Screen.height - Input.mousePosition.y) - (crosshairImage.height / 2);

        GUI.DrawTexture(new Rect(xMin, yMin, crosshairImage.width, crosshairImage.height), crosshairImage);
    }
}
