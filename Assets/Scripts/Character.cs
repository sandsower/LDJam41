using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    public Collider2D cd;
    public Animator an;

    public bool isDying = false;
    public int deathTime = 3;
    public float damageTime = 1;

    public IEnumerator StartDamageAnimation()
    {
        StartBlinking();

        yield return new WaitForSeconds(damageTime);

        StopBlinking();
    }

    public void StartBlinking()
    {
        InvokeRepeating("Blink", 0, 0.07f);
    }

    void Blink()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = !gameObject.GetComponent<SpriteRenderer>().enabled;
    }

    public void StopBlinking()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        CancelInvoke("Blink");
    }

    public IEnumerator StartDeathAnimation(bool shouldBlink)
    {
        an.SetBool("IsDead", true);
        isDying = true;
        cd.enabled = false;

        if (shouldBlink)
        {
            InvokeRepeating("Blink", 0, 0.07f);
        }

        yield return new WaitForSeconds(deathTime);

        Destroy(gameObject);
    }
}
