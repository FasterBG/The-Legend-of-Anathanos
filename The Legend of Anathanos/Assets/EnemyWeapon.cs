using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{

    private Vector2 direction;

    public float startTimeBtwShots;

    private float timeBtwShots;

    private bool pointingRight;

    private Transform player;

    public GameObject bulletPre;
    public Transform firePoint;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = startTimeBtwShots;
    }
    void Update()
    {
        facePlayer();
    }
    void FixedUpdate()
    {
        if (timeBtwShots <= 0)
        {
            Instantiate(bulletPre, firePoint.position, firePoint.rotation);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
    void facePlayer()
    {
        Vector2 direction = new Vector2(player.position.x-transform.position.x, player.position.y-transform.position.y);
        transform.up = direction;
        transform.Rotate(0, 0, 90);
        if (transform.localRotation.z > 0.7f)
        {
            pointingRight = false;
            transform.Rotate(0, 180, -180);
        }
        else
        {
            pointingRight = true;
        }
    }

}
