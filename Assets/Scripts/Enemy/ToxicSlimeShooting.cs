using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToxicSlimeShooting : MonoBehaviour
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
    Vector3 startScale;
    public ParticleSystem dustEffectEnemy;

    bool bulletToxicSize = false;
    public GameObject toxicZone;

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
                //bulletVar.transform.localScale += new Vector3(0.1f,0.1f,0.1f);
                //Vector3 tempScale =  bulletVar.transform.localScale;
                //tempScale.x += Time.deltaTime*100;
                //Debug.Log("Obecna skala "+ bulletVar.transform.localScale);
                //bulletVar.transform.localScale = tempScale;
                timeBetweenShots = Random.Range(1.0f, 4.0f);
                nextShotTime = Time.time + timeBetweenShots;

            }
        }

        if (bulletVar != null)
        {
            if (bulletVar.transform.localScale.x <= 2.8f && bulletToxicSize == false)
            {
                bulletVar.transform.localScale += new Vector3(0.05f, 0.05f, 0.05f)*0.5f;
            }
            if (bulletVar.transform.localScale.x >= 2.4f)
            {
                bulletToxicSize = true;
            }
            if (bulletToxicSize)
            {
                bulletVar.transform.localScale -= new Vector3(0.05f, 0.05f, 0.05f) * 0.5f;
            }
            if (bulletVar.transform.localScale == new Vector3(0.6f, 0.6f, 0.6f))
            {
                Instantiate(toxicZone, bulletVar.transform.position, Quaternion.identity);
                Destroy(bulletVar);
            }

            Debug.Log("Obecna skala " + bulletVar.transform.localScale);
        }

        




    }
}
