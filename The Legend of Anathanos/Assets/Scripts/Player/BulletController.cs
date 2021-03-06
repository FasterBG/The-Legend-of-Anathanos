﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    public float speed;
    public float damage,buff_time;

    public GameObject impactEffect;

    private Vector2 direction;

    private Vector2 target;


    public Rigidbody2D rb;

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.tag != "SpawnPoint")
        {
            EnemyController enemy = hitInfo.GetComponent<EnemyController>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
            Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
