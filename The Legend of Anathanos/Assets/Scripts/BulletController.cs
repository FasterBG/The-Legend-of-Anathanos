using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    public float speed;
    public float damage;

    public Rigidbody2D rb;

    void FixedUpdate()
    {
        rb.velocity = transform.right * speed;
    }
}
