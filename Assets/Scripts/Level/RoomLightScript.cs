using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class RoomLightScript : MonoBehaviour
{
    public Light2D lightMain;
    public Light2D[] lightWall;

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
        if(collision.CompareTag("Player"))
        {
            lightMain.intensity = 1;
            foreach (Light2D light in lightWall)
            {
                light.intensity = 0.3f;
            }

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            lightMain.intensity = 0.5f;
            foreach (Light2D light in lightWall)
            {
                light.intensity = 0;
            }

        }
    }
}
