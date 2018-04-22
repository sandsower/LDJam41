﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {

    public Rigidbody2D playerRigidBody;
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;

    public float movementSpeed = 200f;
    public float movementVertical = 0f;
    public float movementHorizontal = 0f;
    public float pushBackSpeed = 2f;

    public int health = 3;

    public Animator animator;


    public delegate void OnPlayerHit(int currentHealth);
    public event OnPlayerHit onPlayerHit;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        playerRigidBody = GetComponent<Rigidbody2D>();

        cd = GetComponent<Collider2D>();
        an = GetComponent<Animator>();
        damageTime = 3f;

        if (onPlayerHit != null)
        {
            onPlayerHit(health);
        }
    }

    bool IsPlayerMoving() {
        return movementHorizontal != 0f || movementVertical != 0f;
    }

    void FireBullet()
    {
        Vector2 firePosition = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));

        Vector2 direction = firePosition - (Vector2) transform.position;
        direction.Normalize();

        GameObject firedShot = (GameObject) Instantiate(bulletPrefab, bulletSpawnPoint);
        firedShot.GetComponent<Rigidbody2D>().velocity = direction * 6;

        firedShot.GetComponent<IProjectile>().ShakeCamera();

        Destroy(firedShot, 2f);
    }
	
	// Update is called once per frame
	void Update () {
        if(!isDying) { 
            // Get Player movement
            movementHorizontal = Input.GetAxisRaw("Horizontal");
            movementVertical = Input.GetAxisRaw("Vertical");

            if(Input.GetButtonDown("Fire1"))
            {
                FireBullet();
            }

            animator.SetBool("IsMoving", IsPlayerMoving());
        }
    }

    void FixedUpdate()
    {
        Vector2 velocity = playerRigidBody.velocity;
        velocity.x = movementHorizontal * movementSpeed * Time.deltaTime;
        velocity.y = movementVertical * movementSpeed * Time.deltaTime;

        playerRigidBody.velocity = velocity;
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
                StartCoroutine(StartDeathAnimation(false));
            }
        }
    }
}
