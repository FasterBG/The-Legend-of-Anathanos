using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour {

    [SerializeField]
    private int openingDirection;

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
        //Spawn();
        Invoke("Spawn", 1f);
    }

    void Spawn()
    {
        if (spawned == false)
        {
            if (openingDirection == 1)
            {
                if (templates.areThereEnoughRooms())
                {
                    Instantiate(templates.closedRooms[2], transform.position, transform.rotation);
                }
                else
                {
                    rand = Random.Range(0, templates.bot.Length);
                    Instantiate(templates.bot[rand], transform.position, transform.rotation);
                }
            }
            else if (openingDirection == 2)
            {
                if (templates.areThereEnoughRooms())
                {
                    Instantiate(templates.closedRooms[0], transform.position, transform.rotation);
                }
                else
                {
                    rand = Random.Range(0, templates.top.Length);
                    Instantiate(templates.top[rand], transform.position, transform.rotation);
                }
            }
            else if (openingDirection == 3)
            {

                if (templates.areThereEnoughRooms())
                {
                    Instantiate(templates.closedRooms[1], transform.position, transform.rotation);
                }
                else
                {
                    rand = Random.Range(0, templates.left.Length);
                    Instantiate(templates.left[rand], transform.position, transform.rotation);
                }
            }
            else if (openingDirection == 4)
            {

                if (templates.areThereEnoughRooms())
                {
                    Instantiate(templates.closedRooms[3], transform.position, transform.rotation);
                }
                else
                {
                    rand = Random.Range(0, templates.right.Length);
                    Instantiate(templates.right[rand], transform.position, transform.rotation);
                }
            }
            templates.addedRoom();
        spawned = true;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "SpawnPoint")
        {
            if (other.GetComponent<RoomSpawner>() == null)
            {
                Destroy(gameObject);
            }else if(other.GetComponent<RoomSpawner>().spawned == true)
            {
                Destroy(gameObject);
            }
        }
    }
}
