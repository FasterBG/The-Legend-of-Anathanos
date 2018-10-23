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

    public int directionOfPlayer = 0;
    /*
     * direction = 0; right
     * 1=up
     * 2=left
     * 3=right
     */
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
            directionOfPlayer = 0;
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            if (Input.GetKey(left))
            {
                directionOfPlayer = 2;
                rb.velocity = new Vector2(-speed, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
            }
        }
        if (Input.GetKey(up))
        {
            directionOfPlayer = 1;
            rb.velocity = new Vector2(rb.velocity.x, speed);
        }
        else
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);  
            if (Input.GetKey(down))
            {
                directionOfPlayer = 3;
                rb.velocity = new Vector2(rb.velocity.x, -speed);
            }
            else
            {
                rb.velocity = new Vector2(rb.velocity.x, 0);
            }
        }
        if (directionOfPlayer == 0)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else
        {
            if(directionOfPlayer == 1)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, 90f);
            }
            else
            {
                if (directionOfPlayer == 2)
                {
                    transform.rotation = Quaternion.Euler(0f, 0f, 180f);
                }
                else
                {
                    if(directionOfPlayer == 3)
                    {
                        transform.rotation = Quaternion.Euler(0f, 0f, 270f);
                    }
                }
            }
        }
        /*
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        firePoint.transform.up = direction;
        */
    }
}
