using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupItems : MonoBehaviour
{
    public Text coinCounter;
    int coinCounterInt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (coinCounterInt == 0)
        {
            coinCounter.text = "0";
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ammo"))
        {
            PlayerShooting shootScript = gameObject.GetComponent<PlayerShooting>();
            shootScript.bulletMaxNumber = shootScript.bulletMaxNumber + 10;
            collision.GetComponent<Collider2D>().enabled = false;
            //Destroy(collision.gameObject);
            
        }

        if (collision.CompareTag("Coin"))
        {
            
            coinCounterInt++;
            coinCounter.text = coinCounterInt.ToString();
            collision.GetComponent<Collider2D>().enabled = false;
            //Destroy(collision.gameObject);
            
        }
    }




}
