using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public GameObject HealthBar;
    public float currnetHealth = 100;
    public bool hit = false;
    public bool hitToxic = false;
    public int rand;

    public Material defaultMat;
    public Material flashMat;

    [Header("Death Screen")]
    public Animator animatorDeath;
    public Animator animatorPlayerDeath;
    public GameObject deathScreen;
    public GameObject holder;
    public GameObject playerCircle;


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

        if (currnetHealth <= 0)
        {
            playerCircle.GetComponent<PlayerMovement>().enabled = false;
            playerCircle.GetComponent<MousePosition>().enabled = false;
            gameObject.GetComponent<PlayerShooting>().enabled = false;
            holder.SetActive(false);
            animatorPlayerDeath.Play("PlayerDeath");
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

    public void DeathScene()
    {
        deathScreen.SetActive(true);
        animatorDeath.Play("DeathIdle");
    }
}
