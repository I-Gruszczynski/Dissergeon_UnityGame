using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChange : MonoBehaviour
{
    public bool nextLevel = false;
    public bool nextLevelChange = false;
    public int levelCounter = 0;
    public int biomCounter = 0;
    public int counter = 0;
    public GameObject player;
    public GameObject circle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            circle.GetComponent<PlayerMovement>().enabled= false;
            player.GetComponent<PlayerShooting>().enabled= false;
            nextLevel = true;   
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            circle.GetComponent<PlayerMovement>().enabled = true;
            player.GetComponent<PlayerShooting>().enabled = true;
            nextLevel = false;
        }
    }
}
