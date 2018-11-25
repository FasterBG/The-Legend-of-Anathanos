using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    //initializing
    public KeyCode up;
    public KeyCode down;
    public KeyCode left;
    public KeyCode right;

    public Text moneyText;

    public float health;
    public float speed;
    public int money = 0;

    public int directionOfPlayer = 0;
    /*
     * direction = 0; right
     * 1=up
     * 2=left
     * 3=right
     */
    public Rigidbody2D rb;

    void Start()
    {
        moneyText.text = "Money: " + money.ToString();
    }

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
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
