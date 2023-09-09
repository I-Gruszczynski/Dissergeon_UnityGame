using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletDirection : MonoBehaviour
{
    Vector3 targetPosition;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        targetPosition = GameObject.Find("Player").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();

        //transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed*Time.deltaTime);
        //Vector3 direction = targetPosition - transform.position;
        //rb.AddForce( new Vector2(direction.x, direction.y) *speed, ForceMode2D.Impulse);
        //rb.AddForce(gameObject.transform.up, ForceMode2D.Impulse);
    }


}
