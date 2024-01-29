using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupItems : MonoBehaviour
{
    public Text coinCounter;
    public static int coinCounterInt;

    public GameObject rifle;
    public GameObject pistol;
    public GameObject shotgun;
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
        coinCounter.text = coinCounterInt.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ammo"))
        {
            /*
            PlayerShooting shootScript = gameObject.GetComponent<PlayerShooting>();
            shootScript.bulletMaxNumber = shootScript.bulletMaxNumber + 20;
            collision.GetComponent<Collider2D>().enabled = false;
            //Destroy(collision.gameObject);
            Debug.Log("Podniesiono ammo. Obecnie:" + shootScript.bulletMaxNumber);
            */
            if (pistol.activeSelf)
            {
                pistol.GetComponent<PistolShooting>().bulletMaxNumber += 10;
            }
            if (rifle.activeSelf)
            {
                rifle.GetComponent<RifleShooting>().bulletMaxNumber += 30;
            }
            if (shotgun.activeSelf)
            {
                shotgun.GetComponent<ShotgunShooting>().bulletMaxNumber += 16;
            }
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
