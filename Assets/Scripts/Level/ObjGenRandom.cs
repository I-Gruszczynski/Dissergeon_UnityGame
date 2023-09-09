using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjGenRandom : MonoBehaviour
{
    public GameObject[] objects;
    // Start is called before the first frame update
    void Start()
    {
        int rand = Random.Range(0, objects.Length);
        var newObj = Instantiate(objects[rand], transform.position, transform.rotation);
        newObj.transform.parent = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
        
