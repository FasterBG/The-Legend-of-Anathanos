using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public float speed;
    public float health;
    public float damage;
    public float stoppingDistance;
    public float retrearDistance;

    private Transform player;

    public GameObject bulletPre;
    // Use this for initialization
	void Start () {
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
	
	// Update is called once per frame
	void Update () {
        if (Vector2.Distance(transform.position, player.position)>stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if(Vector2.Distance(transform.position, player.position) > stoppingDistance && Vector2.Distance(transform.position, player.position) > retrearDistance)
        {
            transform.position = this.transform.position;
        }
        else if(Vector2.Distance(transform.position, player.position) < retrearDistance)
        {

            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }
	}
}
