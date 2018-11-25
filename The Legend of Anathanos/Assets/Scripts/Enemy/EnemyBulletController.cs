using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{

    public float speed;
    public float damage;

    public GameObject impacteEffect;

    private Transform player;

    private Vector2 target;

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        PlayerController playerInfo = hitInfo.GetComponent<PlayerController>();
        if (playerInfo != null)
        {
            playerInfo.TakeDamage(damage);
        }
        
        Destroy(gameObject);
    }
}
