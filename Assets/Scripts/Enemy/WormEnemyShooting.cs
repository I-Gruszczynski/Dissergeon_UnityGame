using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormEnemyShooting : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 2f;
    public float bulletSpped = 2f;
    public Transform target;
    public float minimumDistance;
    float rand;
    GameObject bulletVar;

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
            transform.position = Vector2.MoveTowards(transform.position, target.position, -speed * Time.deltaTime);

        }
        if (Vector2.Distance(transform.position, target.position) < minimumDistance * 2)
        {
            if (Time.time > nextShotTime)
            {
                bulletVar = Instantiate(bullet, firePoint.position, firePoint.rotation);
                Rigidbody2D rb = bulletVar.GetComponent<Rigidbody2D>();
                rb.AddForce(bulletVar.transform.up * bulletSpped, ForceMode2D.Impulse);
                rb.AddForce(bulletVar.transform.right * bulletSpped, ForceMode2D.Impulse);
                rb.AddForce(bulletVar.transform.up*-1 * bulletSpped, ForceMode2D.Impulse);
                rb.AddForce(bulletVar.transform.right*-1 * bulletSpped, ForceMode2D.Impulse);
                //bulletVar.transform.localScale += new Vector3(0.1f,0.1f,0.1f);
                //Vector3 tempScale =  bulletVar.transform.localScale;
                //tempScale.x += Time.deltaTime*100;
                //Debug.Log("Obecna skala "+ bulletVar.transform.localScale);
                //bulletVar.transform.localScale = tempScale;
                timeBetweenShots = Random.Range(1.0f, 4.0f);
                nextShotTime = Time.time + timeBetweenShots;

            }
        }

    }
}
