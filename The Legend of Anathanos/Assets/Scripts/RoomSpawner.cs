using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour {

    public int openingDirection;

    private bool spawned = false;
    /*
     * 1>bot
     * 2>top
     * 3>left
     * 4>right
    */

    private RoomTemplates templates;
    private int rand;


    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn",0.1f);
    }

    void Spawn()
    {
        if (spawned == false)
        {
            if (openingDirection == 1)
            {
                rand = Random.Range(0, templates.bot.Length);
                Instantiate(templates.bot[rand], transform.position, transform.rotation);
            }
            else if (openingDirection == 2)
            {
                rand = Random.Range(0, templates.top.Length);
                Instantiate(templates.top[rand], transform.position, transform.rotation);
            }
            else if (openingDirection == 3)
            {
                rand = Random.Range(0, templates.left.Length);
                Instantiate(templates.left[rand], transform.position, transform.rotation);
            }
            else if (openingDirection == 4)
            {
                rand = Random.Range(0, templates.right.Length);
                Instantiate(templates.right[rand], transform.position, transform.rotation);
            }
        spawned = true;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("SpawnPoint")){
            if(other.GetComponent<RoomSpawner>().spawned==false && spawned==true)
            {
                Instantiate(templates.closedRooms[rand], transform.position, transform.rotation);
                Debug.Log("*");
                Destroy(gameObject);
            }
            spawned = true;
        }
    }
}
