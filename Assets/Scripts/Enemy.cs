using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class Enemy : MonoBehaviour, Damageable
{
    private int lifeTotal = 1;
    protected Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        EnemyStart();
    }

    protected abstract void EnemyStart();

    public void TakeDamage(int damage)
    {
        lifeTotal -= damage;
        if (lifeTotal <= 0)
        {
            Die();
        }
    }

    protected abstract void Die();
}
