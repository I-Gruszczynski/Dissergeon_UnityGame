using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapRoomLightScript : MonoBehaviour
{
    public GameObject floorTile;
    public GameObject questionSquare;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            floorTile.GetComponent<SpriteRenderer>().color = new Color32(136, 136, 136, 255);
            questionSquare.gameObject.SetActive(false);

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            floorTile.GetComponent<SpriteRenderer>().color = new Color32(68, 68, 68,255);
        }
    }
}
