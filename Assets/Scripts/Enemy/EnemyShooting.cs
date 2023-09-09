using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{

    public float speed = 2f;
    public float bulletSpped = 4f;
    public Transform target;
    public float minimumDistance;
    float rand;

    public GameObject bullet;
    public Transform firePoint;
    public float timeBetweenShots;
    float angle = 10;
    float nextShotTime;

    Vector3 startPos;
    public ParticleSystem dustEffectEnemy;

    // Start is called before the first frame update
    void Start()
    {
        minimumDistance = Random.Range(1.0f, 4.0f);
        target = GameObject.Find("Player").transform;
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (startPos != transform.position)
        {
            if (dustEffectEnemy.isPlaying == false)
            {
                dustEffectEnemy.Play();
                dustEffectEnemy.enableEmission = true;
            }
        }

        if (startPos == transform.position)
        {
            if (dustEffectEnemy.isStopped == false)
            {
                dustEffectEnemy.Stop();
                dustEffectEnemy.enableEmission = false;
            }
        }

        if (Vector2.Distance(transform.position, target.position) < minimumDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, -speed *Time.deltaTime);
            
        }
        if (Vector2.Distance(transform.position, target.position) < minimumDistance*2)
        {
            if (Time.time > nextShotTime)
            {
                GameObject bulletVar = Instantiate(bullet, firePoint.position, firePoint.rotation);
                Rigidbody2D rb = bulletVar.GetComponent<Rigidbody2D>();
                rb.AddForce(bulletVar.transform.up * bulletSpped, ForceMode2D.Impulse);
                timeBetweenShots = Random.Range(1.0f, 4.0f);
                nextShotTime = Time.time + timeBetweenShots;

            }
        }




    }
}
