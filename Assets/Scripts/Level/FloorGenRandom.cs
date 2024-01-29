using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorGenRandom : MonoBehaviour
{
    public Sprite[] sprites;
    public Sprite firstFloorSprite;
    public Sprite chestFloorSprite;
    // Start is called before the first frame update
    void Start()
    {
        if (transform.parent.name != "TRBL" && !transform.parent.Find("Chest") && !transform.parent.Find("TempStairs1"))
        {
            foreach (var sprite in sprites)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)];
            }
        }

        if (transform.parent.name == "TRBL")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = firstFloorSprite;
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (transform.parent.Find("Chest"))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = chestFloorSprite;
            Debug.Log("Jest skrzynia");
        }
        if (transform.parent.Find("TempStairs1"))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = firstFloorSprite;
        }
    }
}
