using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadGuySlow  : BadGuyTemplate
{
    void Start()
    {
        health = 10;
        speed = .2f;
        enemyDifficulty = 3;
        scoreValue = 10;
    }
}

