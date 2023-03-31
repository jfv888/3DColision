using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerControl : MonoBehaviour, Damageable
{
    private Rigidbody rb;
    private Camera cam;
    private Vector3 movement;
    public int movementSpeed = 42;
    public float fireDelay = 0.1f;
    private float delayBeforeNextFire = 0;
    public GameObject bulletPrefab;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
        ProcessFire();
    }

    private void ProcessInput()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.z = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        Move();
        OrientPlayer();
    }

    private void Move()
    {
        rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime);
    }

    private void OrientPlayer()
    {
        (bool, Vector3) result = FindPositionOfMouse();
        if (!result.Item1) { return; }
        result.Item2.y = rb.position.y;
        Vector3 relativePosition = result.Item2 - transform.position;
        Quaternion quaternionRotation = Quaternion.LookRotation(relativePosition, Vector3.up);
        rb.MoveRotation(quaternionRotation);
    }

    private (bool, Vector3) FindPositionOfMouse()
    {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit, 1000))
        {
            return (true, new Vector3(hit.point.x, hit.point.y, hit.point.z));
        }
        else
        {
            return (false, Vector3.zero);
        }

    }

    private void ProcessFire()
    {
        delayBeforeNextFire -= Time.deltaTime;
        if (delayBeforeNextFire <= 0 && Input.GetAxis("Fire1") != 0)
        {
            ShootBullet();
            delayBeforeNextFire = fireDelay;
        }
    }

    private void ShootBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, 
                                        transform.position + transform.forward * 4, 
                                        transform.rotation);

    }

    public void TakeDamage(int damage)
    {
        print("Ouch!");
    }
}
