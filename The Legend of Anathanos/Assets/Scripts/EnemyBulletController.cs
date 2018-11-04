using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{

    public float speed;
    public float damage;

    private Transform player;

    private Vector2 target;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = player.position;
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, target) < 0.2f)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        PlayerController playerInfo = hitInfo.GetComponent<PlayerController>();
        if (playerInfo != null)
        {
            playerInfo.TakeDamage(damage);
            Destroy(gameObject);
        }

    }
}
