using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    private Rigidbody rb;
    private float timeLeftToLive;
    public float lifeSpan = 3;
    public int speed = 42;
    public int damage = 1;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        timeLeftToLive = lifeSpan;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        ApplyLifeSpan();
    }

    private void Move()
    {
        rb.MovePosition(transform.position + transform.forward * speed * Time.fixedDeltaTime);
    }

    private void ApplyLifeSpan()
    {
        timeLeftToLive -= Time.fixedDeltaTime;
        if(timeLeftToLive <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
