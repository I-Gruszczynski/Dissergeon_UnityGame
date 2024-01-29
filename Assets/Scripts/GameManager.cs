using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using System.Numerics;
using UnityEditor.Animations;

public class GameManager : MonoBehaviour
{
    public Animator animator;
    public Animator animatorStart;
    public GameObject stairs;
    public GameObject player;
    bool nextLevel;
    public int fadeComplete = 0;
    public static int levelCounter = 1;
    static int biomCounter = 0;
    public Text floorLevelText;
    float counter;
    public bool complete = false;
    public bool completeStart = false;
    static bool counterStart = true;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
            nextLevel = stairs.GetComponent<LevelChange>().nextLevel;
            //levelCounter = stairs.GetComponent<LevelChange>().levelCounter;
            //biomCounter = stairs.GetComponent<LevelChange>().biomCounter;
            //Debug.Log("Next Level: "+nextLevel);
            if (nextLevel == true)
            {
                //floorLevelText.text = "Level "+biomCounter+"-"+levelCounter;
                animator.SetBool("FadeIn", true);
                player.GetComponent<PlayerMovement>().enabled = false;
                player.GetComponent<PlayerShooting>().enabled = false;
                fadeComplete++;
            }
            //Debug.Log("Poziom " + levelCounter);
            if (fadeComplete == 1)
            {
                levelCounter++;
                Debug.Log("Poziom " + levelCounter);
                Debug.Log("Fade Complete " + fadeComplete);
                if (levelCounter % 5 == 0)
                {
                    biomCounter++;
                    levelCounter = 1;
                }
                floorLevelText.text = "Level " + biomCounter + "-" + levelCounter;

            }

        if (counterStart)
        {
            animatorStart.SetBool("isPlay", true);
        }
        else
        {
            animatorStart.SetBool("isPlay", false);
        }
       
        Debug.Log("Zmeinna startowa: "+counterStart);

    }
    /*
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Schody jest");
            if (animator != null || animator.isActiveAndEnabled)
            {
                animator.SetBool("FadeIn", true);
                Debug.Log("Gra");
            }

        }
    }
    */


public void OnFadeComplete()
    {
        complete= true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Fade " + levelCounter);
        player.GetComponent<PlayerMovement>().enabled = true;
        player.GetComponent<PlayerShooting>().enabled = true;
        complete = false;
    }

    public void StartComplete()
    {
        counterStart = false;
    }

}

