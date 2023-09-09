using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public GameObject HealthBar;
    public float currnetHealth = 100;
    public bool hit = false;
    public bool hitToxic = false;
    public int rand;

    public Material defaultMat;
    public Material flashMat;

    private void Start()
    {

    }
    private void Update()
    {
        if (hit)
        {
            StartCoroutine(FlashWhite());
            rand = Random.Range(5, 20);
            currnetHealth = currnetHealth - rand;
            hit = false;
        }

        if (hitToxic)
        {
            StartCoroutine(FlashWhite());
            rand = Random.Range(1, 5);
            currnetHealth = currnetHealth - rand;
            StartCoroutine(ToxicImmune());
            hitToxic = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BulletEnemy"))
        {
            hit = true;
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("ToxicZone"))
        {
            hitToxic = true;
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
    IEnumerator ToxicImmune()
    {
        hitToxic = false;
        yield return new WaitForSeconds(1f);

    }
}
