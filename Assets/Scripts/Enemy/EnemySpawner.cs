using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using Pathfinding;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] doors;
    public GameObject[] enemies;
    bool playerVisit = false;
    float rand1;
    float rand2;
    int randEnemy;
    float randSpawn;
    float width;
    float height;
    float widthBounds;
    float heightBounds;
    static int fadeComplete;
    public GameObject sceneFade;
    Animator animator;

    public static int forwardSpawn = 0;
    public static int backSpawn = 0;
    int i=0;

    public float levelCounter = 0;
    public static int levelCounterInt = 1;
    bool complete;
    // Start is called before the first frame update
    void Start()
    {
        //Naprawic losowanie (nie od -9 do 9)
        foreach (var door in doors)
        {
            door.SetActive(false);
        }

       
    }

    // Update is called once per frame
    void Update()
    {
        complete = GameObject.Find("SceneFade1").GetComponent<GameManager>().complete;
        //fadeComplete = GetComponent<GameManager>().fadeComplete;
        //levelCounter = GetComponent<GameManager>().levelCounter;
        animator = GameObject.Find("SceneFade1").GetComponent<Animator>();
        if (animator.GetBool("FadeIn") == true)
        {
            Counter();
        }
        /*
        if (levelCounter > 0.0166916)
        {
            levelCounterInt++;
        }
        */
        if (GameObject.FindGameObjectsWithTag("Enemy").Length <= 0)
        {
            foreach (var door in doors)
            {
                door.SetActive(false);
            }
        }
        /*
        if (enemyHealth.GetComponent<EnemyHealth>().obstycleCollisionUpdate == true)
        {
            Debug.Log("Kolizja z obiektem");
        }

        if (enemyHealth.GetComponent<EnemyHealth>().obstycleCollisionUpdate == false)
        {
            Debug.Log("Brak kolizji z obiektem");
        }
        */
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {

            foreach (var door in doors)
            {
                door.SetActive(true);
            }
            if (playerVisit == false)
            {
                AstarPath.active.Scan();
                width = transform.position.x;
                height = transform.position.y;
                widthBounds = GetComponent<SpriteRenderer>().bounds.size.x;
                heightBounds = GetComponent<SpriteRenderer>().bounds.size.y;

                randSpawn = UnityEngine.Random.Range(forwardSpawn + 1, 4 + backSpawn);
                for (int i = 0; i < randSpawn; i++)
                {
                    if (enemies.Length != 0)
                    {
                        rand1 = UnityEngine.Random.Range(width - widthBounds / 2 + 1, width + widthBounds / 2 - 1);
                        rand2 = UnityEngine.Random.Range(height - heightBounds / 2 + 1, height + heightBounds / 2 - 1);


                        randEnemy = UnityEngine.Random.Range(0, enemies.Length);
                        Debug.Log("Indeks przeciwnika: " + randEnemy);
                        Debug.Log("D³ugpsc przeciwnika: " + enemies.Length);
                        var enemySpawn = Instantiate(enemies[randEnemy], new Vector2(rand1, rand2), transform.rotation);
                        enemySpawn.transform.parent = gameObject.transform;


                        Debug.Log("Liczba przeciwnikow powinna wynosic " + randSpawn);
                    }
                }
                if (GameObject.FindGameObjectsWithTag("Enemy").Length > 0)
                {
                    randEnemy = UnityEngine.Random.Range(0, enemies.Length);
                    Debug.Log("Indeks przeciwnika: " + randEnemy);
                    var enemySpawn = Instantiate(enemies[randEnemy], new Vector2(rand1, rand2), transform.rotation);
                        enemySpawn.transform.parent = gameObject.transform;
                   
                }
            }
            playerVisit = true;
        }

        
    }

    void Counter()
    {
        if (complete == true) 
        {
            levelCounterInt++;
        }
    }


}
