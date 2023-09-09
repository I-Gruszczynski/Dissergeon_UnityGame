using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorridorEnd : MonoBehaviour
{
    public GameObject corridorDest;
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
        if (collision.CompareTag("Wall") && collision.CompareTag("Triangle"))
        {
            Debug.Log("Kolizja korytarz "+collision.name);
            Instantiate(corridorDest, transform.position, Quaternion.identity);

        }
    }

}
