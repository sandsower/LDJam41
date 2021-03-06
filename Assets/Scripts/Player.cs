﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {

    public Rigidbody2D playerRigidBody;
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;

    public CardHolder cardHolder;

    public float movementSpeed = 200f;
    public float movementVertical = 0f;
    public float movementHorizontal = 0f;
    public float pushBackSpeed = 2f;

    public int health = 3;
    public float reshuffleSpeed = 1.0f;

    bool shufflingDeck;
    bool shouldStopMoving;

    public Animator animator;

    public delegate void OnPlayerHit(int currentHealth);
    public event OnPlayerHit onPlayerHit;

    public delegate void OnPlayerDeath();
    public event OnPlayerDeath onPlayerDeath;


    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        playerRigidBody = GetComponent<Rigidbody2D>();
        shouldStopMoving = false;

        shufflingDeck = false;

        cd = GetComponent<Collider2D>();
        an = GetComponent<Animator>();
        damageTime = 3f;

        if (onPlayerHit != null)
        {
            onPlayerHit(health);
        }

        cardHolder.deck.onCardPlayed += OnCardPlayed;
        cardHolder.deck.onStartReshuffling += OnStartReshuffling;
        cardHolder.deck.onFinishReshuffling += OnFinishReshuffling;
    }

    private void OnFinishReshuffling()
    {
        shufflingDeck = false;
    }

    private void OnStartReshuffling()
    {
        shufflingDeck = true;
    }

    void OnCardPlayed(Card cardPlayed)
    {
        FireProjectile(cardPlayed.GetProjectile());
    }

    bool IsPlayerMoving() {
        return movementHorizontal != 0f || movementVertical != 0f;
    }

    void FireProjectile(IProjectile projectile)
    {
        Vector2 firePosition = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));

        Vector2 direction = firePosition - (Vector2) transform.position;
        direction.Normalize();

        GameObject firedShot = Instantiate(projectile.GetObjectToInstantiate(), bulletSpawnPoint);
        firedShot.GetComponent<Rigidbody2D>().velocity = direction * projectile.GetProjectileSpeed();

        CameraShaker cameraShaker = GetComponent<CameraShaker>();

        firedShot.GetComponent<IProjectile>().ShakeCamera(cameraShaker);

        Destroy(firedShot, projectile.GetMaxTimelimit());
    }
	
	// Update is called once per frame
	void Update () {
        if(!isDying) { 
            // Get Player movement
            if(!shouldStopMoving) {
                movementHorizontal = Input.GetAxisRaw("Horizontal");
                movementVertical = Input.GetAxisRaw("Vertical");
            }

            if (Input.GetButtonDown("Fire1"))
            {
                if (!shufflingDeck)
                {
                    if (cardHolder.deck.IsDeckEmpty() && cardHolder.deck.IsHandEmpty())
                    {
                        StartCoroutine(cardHolder.deck.StartRefillDeckCoroutine(reshuffleSpeed));
                    } else {
                        if (cardHolder.deck.IsHandEmpty())
                        {
                            cardHolder.deck.RefillHand();
                        }
                        else
                        {
                            cardHolder.deck.GetNextCard();
                        }
                    }
                }
            } else if(Input.GetButtonDown("Fire2")) {
                StartCoroutine(cardHolder.deck.StartRefillDeckCoroutine(reshuffleSpeed));
            }
        }
    }

    void FixedUpdate()
    {
        Vector2 velocity = playerRigidBody.velocity;
        velocity.x = movementHorizontal * movementSpeed * Time.deltaTime;
        velocity.y = movementVertical * movementSpeed * Time.deltaTime;

        playerRigidBody.velocity = velocity;

        animator.SetBool("IsMoving", IsPlayerMoving());
    }

    IEnumerator MakeInvulnerable(float time)
    {
        cd.enabled = false;

        yield return new WaitForSeconds(time);

        cd.enabled = true;
    }

    public void TakeDamage(Collider2D collision)
    {
        if (!isDying) { 
            health -= 1;

            if (onPlayerHit != null)
            {
                onPlayerHit(health);
            }

            StartCoroutine(StartDamageAnimation());

            StartCoroutine(MakeInvulnerable(damageTime));

            if (health == 0)
            {
                StopAllCoroutines();

                if (onPlayerDeath != null)
                {
                    onPlayerDeath();
                }

                StartCoroutine(StartDeathAnimation(false));
            }
        }
    }
}
