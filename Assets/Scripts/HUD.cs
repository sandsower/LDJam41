using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

    public Player player;

    public Sprite[] healthSprites;

    public Image healthUI;

	// Use this for initialization
	void Start () {
        player.onPlayerHit += updateHealth;
	}

    void updateHealth (int currentHealth) {
        healthUI.sprite = healthSprites[currentHealth];
    }
}
