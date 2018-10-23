using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    public float speed;
    public float damage;

    public Rigidbody2D rb;
    public PlayerController player;

    private Vector2 target;
    private float k;

    void Start()
    {
        player = GetComponent<PlayerController>();
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        k = target.x / target.y;
        
        if (target.x > transform.position.x && target.y > transform.position.y)
        {
            target.x += 10;
        }
        if (target.x > transform.position.x && target.y < transform.position.y)
        {
            target.x += 10;
        }
        if (target.x < transform.position.x && target.y > transform.position.y)
        {
            target.x -= 10;
        }
        if (target.x < transform.position.x && target.y < transform.position.y)
        {
            target.x -= 10;
        }
        if (target.x == transform.position.x && target.y > transform.position.y)
        {
            target.x -= 10;
        }
        if (target.x == transform.position.x && target.y < transform.position.y)
        {
            target.x -= 10;
        }
        if (target.x < transform.position.x && target.y == transform.position.y)
        {
            target.x += 10;
        }
        if (target.x > transform.position.x && target.y == transform.position.y)
        {
            target.x += 10;
        }
        target.y = target.x/k;
    }

    void Update()
    {   
        transform.position = Vector2.MoveTowards(transform.position, target, speed);
        if (Vector2.Distance(transform.position,target)<0.2f)
        {
            Destroy(gameObject);
        }
    }
}
