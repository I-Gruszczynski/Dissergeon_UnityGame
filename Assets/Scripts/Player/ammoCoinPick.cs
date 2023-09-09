using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammoCoinPick : MonoBehaviour
{
    float yPos;
    bool isPick = false;
    float secondsCount;
    // Start is called before the first frame update
    void Start()
    {
        yPos = transform.position.y + 1f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isPick)
        {
            transform.Rotate(0,10,0);
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, yPos), 10* Time.deltaTime);
            secondsCount += Time.deltaTime;

            if (secondsCount >= 0.5)
            {
                secondsCount= 0;
                Destroy(gameObject);
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPick = true;
        }
    }
}
