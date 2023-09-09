using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LastRoomObjDelete : MonoBehaviour
{
    public List<GameObject> rooms;
    bool lastRoom = true;
    float counter = 0;
    bool collisionDetech = true;
    public GameObject[] randomObjects;
      // Start is called before the first frame update
    void Start()
    {
        rooms = GameObject.FindGameObjectWithTag("RoomsTemp").GetComponent<RoomTemplates>().rooms;
        int enemyNumber = rooms[0].transform.Find("Floor").transform.childCount;
        for (int j = 0; j < enemyNumber; j++)
        {
            rooms[0].transform.Find("Floor").GetChild(j).gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*
        counter += Time.deltaTime;

        Debug.Log(counter);
        if (counter > 5)
        {
        */
        for (int i = 0; i < rooms.Count; i++)
            {
                if (i == rooms.Count - 1)
                {

                    int enemyNumber = rooms[i].transform.Find("Floor").transform.childCount;
                    for (int o = 0; o < enemyNumber; o++)
                    {
                        rooms[i].transform.Find("Floor").GetChild(o).gameObject.SetActive(false);
                    }
                }
            }
        //}
        
    }
}
