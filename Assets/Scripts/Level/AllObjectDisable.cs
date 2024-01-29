using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllObjectDisable : MonoBehaviour
{
    public GameObject AllObject;
    public GameObject chest;
    public GameObject stairs;
    // Start is called before the first frame update
    void Start()
    {

            AllObject.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (AllObject)
        {
            if (collision.CompareTag("Player"))
            {
                AllObject.SetActive(true);
            }
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (AllObject)
        {
            if (collision.CompareTag("Player"))
            {
                AllObject.SetActive(false);
            }
        }
    }
}
