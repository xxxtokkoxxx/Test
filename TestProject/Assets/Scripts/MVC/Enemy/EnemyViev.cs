using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyViev : Element
{
    public GameObject enemy;
    [HideInInspector]
    public Rigidbody enemyRb;

    private void Start()
    {
        enemyRb = enemy.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        App.enemyController.CatchBall();
    }
}
