using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    private float timeWhenLastShooted;
    private Vector2 direction;

    private bool isCooldown=false;
    private bool pointingRight = true;
    private bool oldPointinRight = true;

    public float cooldownValue;
    public float bulletSpeed;

    public GameObject bulletPre;
    public Transform firePoint;
    public GameObject cross;

    void Update()
    {
        Cursor.visible = false;
        faceMouse();
    }
    void FixedUpdate()
    {
        if (Input.GetMouseButton(0) && isCooldown==false)
        {
            //Time.time - Измерва времето от началото на играта
            timeWhenLastShooted = Time.time;

            isCooldown = true;
            Shoot();
        }
        if(Time.time - timeWhenLastShooted >= cooldownValue)
        {
            isCooldown = false;
        }
    }
    void Shoot()
    {  
        GameObject bullet = Instantiate(bulletPre, firePoint.position, Quaternion.identity);
    }
    void faceMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        cross.transform.position = new Vector3(mousePosition.x, mousePosition.y, 10);

        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        transform.up = direction;
        transform.Rotate(0, 0, 90);
        Debug.Log(transform.localRotation.z);
        if(transform.localRotation.z>0.7f)
        {
            pointingRight = false;
            transform.Rotate(0, 180, -180);
        }
        else
        {
            pointingRight = true;
        }
        if (pointingRight != oldPointinRight)
        {
            Debug.Log("Rotate");
        }
        oldPointinRight = pointingRight;
    }
}
