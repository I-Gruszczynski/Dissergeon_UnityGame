using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class PlayerExp : MonoBehaviour
{
    public Text playerLevel;
    public Slider  expBar;
    GameObject[] enemies;

    int enemyHealth;
    int playerLevelInt;
    bool nextLevel = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {       

        if (expBar.value >= expBar.maxValue)
        {
                nextLevel = true;
                expBar.value = 0;
                expBar.maxValue = expBar.maxValue + 10;
           
        }

        if (nextLevel)
        {
            playerLevelInt++;
            nextLevel = false;
        }

        playerLevel.text = playerLevelInt.ToString();
    }
}
