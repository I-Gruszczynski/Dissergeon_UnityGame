using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    public GameObject[] bottomRooms;
    public GameObject[] rightRooms;
    public GameObject[] topRooms;
    public GameObject[] leftRooms;

    public GameObject closedRooms;

    public List<GameObject> rooms;

    public float waitTime = 2f;
    private bool spawnStairs;
    private bool spawnChest;
    public GameObject stairs;
    public GameObject chest;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (waitTime <= 0 && spawnStairs == false && spawnChest == false)
        {
            for (int i = 0; i < rooms.Count; i++)
            {
                
                //if (rooms[i].gameObject.name == "R(Clone)" || rooms[i].gameObject.name == "L(Clone)" || rooms[i].gameObject.name == "T(Clone)" || rooms[i].gameObject.name == "B(Clone)")
                if ((rooms[i].gameObject.name == "R(Clone)" || rooms[i].gameObject.name == "L(Clone)" || rooms[i].gameObject.name == "T(Clone)" || rooms[i].gameObject.name == "B(Clone)") && i != rooms.Count - 1)
                {
                    //if (rooms[i].gameObject.transform.Find("TempStairs1"))
                    //{
                    //    return;
                    //}
                    //else
                    //{
                        Debug.Log("Znaleziono");
                        chest.transform.position = new Vector3(rooms[i].transform.position.x, rooms[i].transform.position.y, -2f);
                        
                        chest.gameObject.transform.SetParent(rooms[i].transform);
                        spawnChest = true;
                    if (!rooms[i].gameObject.transform.Find("Chest"))
                    {
                        rooms[i].transform.Find("AllRandomObj").gameObject.SetActive(true);
                    }
                    if (rooms[i].gameObject.transform.Find("Chest"))
                    {
                        Destroy(rooms[i].transform.Find("AllRandomObj").gameObject);
                        Debug.Log("Zmaleziono w pokoju " + rooms[i].gameObject.name);
                        break;
                    }
                    //rooms[i].transform.Find("AllRandomObj").gameObject.SetActive(false);
                    //Destroy(rooms[i].transform.Find("AllRandomObj").gameObject);
                    //}
                }
                if (rooms[i].gameObject.transform.Find("TempStairs1"))
                {
                    Destroy(rooms[i].transform.Find("AllRandomObj").gameObject);
                }
                
            }
            for (int i = 0; i < rooms.Count; i++)
            {
                if (i == rooms.Count - 1)
                {
                    Debug.Log("Spwan schodow");
                    /*
                    rooms[i].transform.localScale = new Vector2(2, 2);
                    if (GameObject.Find("B") == rooms[i].gameObject)
                    {
                        rooms[i].transform.position = new Vector2(transform.position.x,transform.position.y + 20);
                    }
                    if (GameObject.Find("T") == rooms[i].gameObject)
                    {
                        rooms[i].transform.position = new Vector2(transform.position.x, transform.position.y - 20);
                    }
                    if (GameObject.Find("L") == rooms[i].gameObject)
                    {
                        rooms[i].transform.position = new Vector2(transform.position.x + 20, transform.position.y);
                    }
                    if (GameObject.Find("R") == rooms[i].gameObject)
                    {
                        rooms[i].transform.position = new Vector2(transform.position.x - 20, transform.position.y);
                    }
                    */
                    //Instantiate(stairs, new Vector3(rooms[i].transform.position.x, rooms[i].transform.position.y, -2f), Quaternion.identity);
                    stairs.transform.position = new Vector3(rooms[i].transform.position.x, rooms[i].transform.position.y, -2f);
                    stairs.gameObject.transform.SetParent(rooms[i].transform);


                    spawnStairs = true;
                    //rooms[i].transform.Find("AllRandomObj").gameObject.SetActive(false);
                    Destroy(rooms[i].transform.Find("AllRandomObj").gameObject);
                }
            }
            }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }
}
