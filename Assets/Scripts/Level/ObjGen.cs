using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjGen : MonoBehaviour
{
    public GameObject[] objects;
    // Start is called before the first frame update
    void Start()
    {
        foreach (var obj in objects)
        {
            Instantiate(obj, transform.position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
