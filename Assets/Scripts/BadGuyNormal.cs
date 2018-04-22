using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D), typeof(Animator))]
public class BadGuyNormal : Character, IEnemy {

    Rigidbody2D rb;

    public int health;
    public float speed = .4f;
    public Player player;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();

        health = 2;
    }

    public void ApplyDamage(Collider2D collider)
    {
        IProjectile projectile = collider.transform.gameObject.GetComponent<IProjectile>();
        health -= projectile.GetDamage();

        if(health <= 0) {
            StopBlinking();
            StartCoroutine(StartDeathAnimation(true));
        } else {
            StopBlinking();
            StartCoroutine(StartDamageAnimation());
        }

        if (projectile.ShouldBeDestroyed()) {
            Destroy(collider.transform.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Projectile"))
        {
            ApplyDamage(collision);
        } else if (collision.CompareTag("Player"))
        {
            player.TakeDamage(collision);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}

    void FixedUpdate() {
        if (!isDying && !player.isDying) {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.localPosition, speed * Time.deltaTime);
        }
    }

    public void setPlayer(Player player)
    {
        this.player = player;
    }
}
