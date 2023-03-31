using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : Enemy
{
    private GameObject player;
    public float speed = 5;

    void FixedUpdate()
    {
        rb.MovePosition(Vector3.MoveTowards(
            transform.position,
            player.transform.position,
            speed * Time.fixedDeltaTime
        ));
    }

    protected override void EnemyStart()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    protected override void Die()
    {
        Destroy(gameObject);
    }
}
