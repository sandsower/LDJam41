using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadGuyFast : BadGuyTemplate {
    void Start()
    {
        health = 1;
        speed = .4f;
        enemyDifficulty = 2;
        scoreValue = 3;
    }
}
