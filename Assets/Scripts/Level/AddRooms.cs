using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AddRooms : MonoBehaviour
{
    RoomTemplates roomTemplates;
    // Start is called before the first frame update
    void Start()
    {
        roomTemplates = GameObject.FindGameObjectWithTag("RoomsTemp").GetComponent<RoomTemplates>();
        roomTemplates.rooms.Add(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
