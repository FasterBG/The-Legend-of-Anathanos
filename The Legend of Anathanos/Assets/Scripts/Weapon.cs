using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    private float timeWhenLastShooted;

    private bool isCooldown=false;

    public float cooldownValue;

    public GameObject bullet;
    public Transform firePoint;

    void Update()
    {
        faceMouse();
    }
    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0) && isCooldown==false)
        {
            //Time.time - Измерва времето от началото на играта
            timeWhenLastShooted = Time.time;
            isCooldown = true;
            Debug.Log("Shooted");
            Shoot();
        }
        if(Time.time - timeWhenLastShooted >= cooldownValue)
        {
            isCooldown = false;
        }
    }
    void Shoot()
    {
        Instantiate(bullet, firePoint.position, Quaternion.identity);
    }
    void faceMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        transform.up = direction;
    }
}
