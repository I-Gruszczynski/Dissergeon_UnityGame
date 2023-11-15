using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    /*
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
    }
    
    public Transform player;
    public float speed = 0.125f;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        offset.z = 1;
    }

    // Update is called once per frame
    void LateUpdate()
    {

        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z) + offset;
    }
    */

    [SerializeField] private Transform playerTransform;

    private float radius = 4f;
    private float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;
    Vector3 newPosition;

    public void FixedUpdate()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        newPosition = new Vector3(
          (mousePosition.x - playerTransform.position.x) / 2f + playerTransform.position.x,
          (mousePosition.y - playerTransform.position.y) / 2f + playerTransform.position.y,
          transform.position.z
        );

        float dist = Vector2.Distance(
          new Vector2(newPosition.x, newPosition.y),
          new Vector2(playerTransform.position.x, playerTransform.position.y)
        );

        if (dist > radius)
        {
            Vector3 mouseOffset = mousePosition - playerTransform.position;
            var norm = mouseOffset.normalized;
            newPosition = new Vector3(
              norm.x * radius + playerTransform.position.x,
              norm.y * radius + playerTransform.position.y,
              transform.position.z
            );
        }

        //transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
    }

    void LateUpdate()
    {

    }
    /*
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.isStatic)
        {
            for (int i = 0; i < collision.transform.childCount; i++)
            {
                collision.transform.GetChild(i).gameObject.SetActive(true);
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (gameObject.isStatic)
        {
            for (int i = 0; i < collision.transform.childCount; i++)
            {
                collision.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
    */
}



