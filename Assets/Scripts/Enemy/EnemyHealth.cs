using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class EnemyHealth : MonoBehaviour
{
    public int enemyHealth = 100;
    public int bulletDamage = 10;
    public bool obstycleCollision;
    public bool obstycleCollisionUpdate;

    public GameObject ammo;
    public GameObject coin;

    float randSpawn;
    float rand1;
    float rand2;

    Text playerLevel;
    int playerLevelInt;
    bool nextLevel = false;
    Slider expBar;

    public Sprite[] spriteObj;
    SpriteRenderer sprite;
    public float knockbackForce;
    Rigidbody2D rb;

    public Material defaultMat;
    public Material flashMat;

    public Transform objTrans;
    private float delay = 0;
    private float pasttime = 0;
    private float when = 3.0f;
    private Vector3 off;

    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        obstycleCollision = false;
        playerLevelInt = 0;

        Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    // Update is called once per frame
    void Update()
    {
        playerLevel = GameObject.Find("PlayerLevel").GetComponent<Text>();
        expBar = GameObject.Find("ExpBar").GetComponent<Slider>();

        if (obstycleCollision == true)
        {
            obstycleCollisionUpdate = true;
            //Destroy(gameObject);
        }

        if (obstycleCollision == false)
        {
            obstycleCollisionUpdate = false;
        }

        //if (nextLevel)
        //{
        // playerLevelInt++;
        //Debug.Log("Poziom wy¿ej " + playerLevelInt);
        //playerLevel.text = playerLevelInt.ToString();
        //nextLevel= false;
        //}


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {

            enemyHealth = enemyHealth - bullet.GetComponent<BulletCollision>().bulletDamage;

            if (enemyHealth <= 0)
            {
                randSpawn = UnityEngine.Random.Range(0, 4);
                for (int i = 0; i < randSpawn; i++)
                {
                    rand1 = UnityEngine.Random.Range(-1f, 1f);
                    rand2 = UnityEngine.Random.Range(-1f, 1f);

                    off = new Vector3(UnityEngine.Random.Range(-3, 3), off.y, off.z);
                    off = new Vector3(off.x, UnityEngine.Random.Range(-3, 3), off.z);
                    //var coinObj = Instantiate(coin, new Vector2(transform.position.x + rand1, transform.position.y + rand2) , Quaternion.identity);
                    var coinObj = Instantiate(coin, transform.position, Quaternion.identity);

                    //StartCoroutine(CoinSplash(coinObj));
                    /*
                    objTrans = coinObj.gameObject.transform;

                    if (when >= delay)
                    {
                        pasttime = Time.deltaTime;
                        objTrans.position += off * Time.deltaTime;
                        delay += pasttime;

                        Debug.Log("Moneta sie rozsypuje");
                    }
                    */

                }

                randSpawn = UnityEngine.Random.Range(0, 2);
                for (int i = 0; i < randSpawn; i++)
                {
                    rand1 = UnityEngine.Random.Range(-1f, 1f);
                    rand2 = UnityEngine.Random.Range(-1f, 1f);

                    Instantiate(ammo, new Vector2(transform.position.x + rand2, transform.position.y + rand1), Quaternion.identity);

                }
                Destroy(gameObject);
                expBar.value = expBar.value + 20;
            }

        }

        if (collision.CompareTag("Obstycle"))
        {
            obstycleCollision = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            rb.isKinematic = true;
        }
        else
        {
            rb.isKinematic = false;
        }

        if (collision.CompareTag("Enemy"))
        {
            Physics2D.IgnoreCollision(collision.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }

        if (collision.CompareTag("Obstycle"))
        {
            obstycleCollision = true;
        }

        if (collision.CompareTag("Bullet"))
        {
            StartCoroutine(FlashWhite());
            Vector2 difference = (transform.position - collision.transform.position).normalized;
            Vector2 force = difference * knockbackForce;
            rb.AddForce(force, ForceMode2D.Impulse);
        }

    }

    IEnumerator FlashWhite()
    {

        gameObject.GetComponent<SpriteRenderer>().material = defaultMat;
        yield return new WaitForSeconds(0.1f);
        gameObject.GetComponent<SpriteRenderer>().material = flashMat;
        yield return new WaitForSeconds(0.1f);
        gameObject.GetComponent<SpriteRenderer>().material = defaultMat;

    }
    /*
    IEnumerator CoinSplash(GameObject coinObj)
    {
        objTrans = coinObj.transform;
        pasttime = Time.deltaTime;
        objTrans.position += off * Time.deltaTime;
        delay += pasttime;

        Debug.Log("Moneta sie rozsypuje");
        yield return new WaitForSeconds(3f);


    }
    */
}
