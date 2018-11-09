using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public float speed;
    public float health;
    public float damage;
    public float patrolCooldown;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    public Transform movingSpots;

    private Transform player;

    public GameObject bulletPre;

    private float waitTime;

	void Start () {
        movingSpots.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        player = GameObject.FindGameObjectWithTag("Player").transform;
	}
    public void TakeDamage(float dmg)
    {
        health -= dmg;
        if (health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
	
	void Update () {
        transform.position = Vector2.MoveTowards(transform.position, movingSpots.transform.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, movingSpots.transform.position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                movingSpots.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
                waitTime = patrolCooldown;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
	}
}
