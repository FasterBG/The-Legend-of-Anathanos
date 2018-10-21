using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    //initializing
    public KeyCode up;
    public KeyCode down;
    public KeyCode left;
    public KeyCode right;

    public float speed;

    public Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        //movement script
        if (Input.GetKey(right))
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            if (Input.GetKey(left))
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
            }
        }
        if (Input.GetKey(up))
        {
            rb.velocity = new Vector2(rb.velocity.x, speed);
        }
        else
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);  
            if (Input.GetKey(down))
            {
                rb.velocity = new Vector2(rb.velocity.x, -speed);
            }
            else
            {
                rb.velocity = new Vector2(rb.velocity.x, 0);
            }
        }
    }
}
