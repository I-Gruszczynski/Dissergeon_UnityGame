using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RoomSpawner : MonoBehaviour
{
    public int openingDirection;
    public GameObject closedRoom;

    private RoomTemplates roomTemplates;
    int rand;
    bool spawned = false;

    // Start is called before the first frame update
    void Start()
    {
        roomTemplates = GameObject.FindGameObjectWithTag("RoomsTemp").GetComponent<RoomTemplates>();
        Invoke("Spawn", 0.1f);
    }

    // Update is called once per frame
    void Spawn()
    {
        if (spawned == false)
        {
            
            if (openingDirection == 1)
            {
                rand = UnityEngine.Random.Range(0, roomTemplates.bottomRooms.Length);
                //Debug.Log("Ile pokoi: "+ roomTemplates.bottomRooms.Length);
                Instantiate(roomTemplates.bottomRooms[rand], transform.position, Quaternion.identity);
            }
            if (openingDirection == 2)
            {
                rand = UnityEngine.Random.Range(0, roomTemplates.rightRooms.Length);
                Instantiate(roomTemplates.rightRooms[rand], transform.position, Quaternion.identity);
            }       
            else if (openingDirection == 3)
            {
                rand = UnityEngine.Random.Range(0, roomTemplates.topRooms.Length);
                Instantiate(roomTemplates.topRooms[rand], transform.position, Quaternion.identity);
            }
            else if (openingDirection == 4)
            {
                rand = UnityEngine.Random.Range(0, roomTemplates.leftRooms.Length);
                Instantiate(roomTemplates.leftRooms[rand], transform.position, Quaternion.identity);
            }
        }
        spawned = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SpawnPoint"))
        {
            if (other.GetComponent<RoomSpawner>().spawned == false && spawned == false)
            {
                Instantiate(closedRoom, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            spawned = true;
        }
        if (other.CompareTag("Room"))
        {
            Destroy(other.gameObject);
            Instantiate(closedRoom, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
