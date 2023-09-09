using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunLayer : MonoBehaviour
{
    public GameObject circle;
    int gunOrder;
    public Vector3 StartRotation;

    public GameObject holder;
    public GameObject gunBox;
    bool canShoot;
    // Start is called before the first frame update
    void Start()
    {

        gameObject.GetComponent<SpriteRenderer>().transform.eulerAngles = StartRotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.parent == holder.transform)
        {
            canShoot = true;
        }
        if (gameObject.transform.parent == gunBox.transform)
        {
            canShoot = false;
        }

        if (canShoot)
        {
            gunOrder = circle.GetComponent<MousePosition>().gunOrder;
            GetComponent<Renderer>().sortingOrder = gunOrder;

            if (circle.transform.localRotation.eulerAngles.z > 0 && circle.transform.localRotation.eulerAngles.z < 180)
            {
                gameObject.GetComponent<SpriteRenderer>().flipY = true;
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().flipY = false;
            }
        }
    }
}
