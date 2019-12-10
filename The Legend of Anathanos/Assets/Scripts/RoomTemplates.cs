using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour {

    public GameObject[] bot;
    public GameObject[] top;
    public GameObject[] left;
    public GameObject[] right;
    public GameObject[] closedRooms;

    [SerializeField]
    private int wantedRooms;

    private int availableRooms = 0;
    
    public bool areThereEnoughRooms()
    {
        if(availableRooms > wantedRooms)
        {
            return true;
        }
        return false;
    }

    public void addedRoom()
    {
        availableRooms++;
    }
}
