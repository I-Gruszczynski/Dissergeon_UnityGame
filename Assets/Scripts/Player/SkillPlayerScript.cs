using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillPlayerScript : MonoBehaviour
{
    public GameObject player;
    public GameObject playerCircle;
    public Slider healthSlider;
    public Slider healthSliderWhite;
    public GameObject rifle;
    public GameObject pistol;
    public GameObject shotgun;
    public GameObject bullet;
    public GameObject levelUp;

    public GameObject btnAddHealth;
    public GameObject btnRestoreHealth;
    public GameObject btnAddAmmo;
    public GameObject btnAddSpeed;
    public GameObject btnAddDamage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (levelUp.activeSelf)
        {
            if (PickupItems.coinCounterInt < 10)
            {
                var colorsResH = btnRestoreHealth.GetComponent<Button>().colors;
                colorsResH.normalColor = Color.red;
                colorsResH.highlightedColor = Color.red;
                colorsResH.selectedColor = Color.red;
                btnRestoreHealth.GetComponent<Button>().colors = colorsResH;

                var colorsAddS = btnAddSpeed.GetComponent<Button>().colors;
                colorsAddS.normalColor = Color.red;
                colorsAddS.highlightedColor = Color.red;
                colorsAddS.selectedColor = Color.red;
                btnAddSpeed.GetComponent<Button>().colors = colorsAddS;

                var colorsAddD = btnAddDamage.GetComponent<Button>().colors;
                colorsAddD.normalColor = Color.red;
                colorsAddD.highlightedColor = Color.red;
                colorsAddD.selectedColor = Color.red;
                btnAddDamage.GetComponent<Button>().colors = colorsAddD;
            }
            else
            {
                var colorsResH = btnRestoreHealth.GetComponent<Button>().colors;
                colorsResH.normalColor = new Color32(17, 69, 132,255);
                colorsResH.highlightedColor = new Color32(11, 47, 91,255);
                btnRestoreHealth.GetComponent<Button>().colors = colorsResH;

                var colorsAddS = btnAddSpeed.GetComponent<Button>().colors;
                colorsAddS.normalColor = new Color32(17, 69, 132, 255);
                colorsAddS.highlightedColor = new Color32(11, 47, 91, 255);
                btnAddSpeed.GetComponent<Button>().colors = colorsAddS;

                var colorsAddD = btnAddDamage.GetComponent<Button>().colors;
                colorsAddD.normalColor = new Color32(17, 69, 132, 255);
                colorsAddD.highlightedColor = new Color32(11, 47, 91, 255);
                btnAddDamage.GetComponent<Button>().colors = colorsAddD;
            }

            if (PickupItems.coinCounterInt < 5)
            {
                var colorsAddH = btnAddHealth.GetComponent<Button>().colors;
                colorsAddH.normalColor = Color.red;
                colorsAddH.highlightedColor = Color.red;
                colorsAddH.selectedColor = Color.red;
                btnAddHealth.GetComponent<Button>().colors = colorsAddH;

                var colorsAddA = btnAddAmmo.GetComponent<Button>().colors;
                colorsAddA.normalColor = Color.red;
                colorsAddA.highlightedColor = Color.red;
                colorsAddA.selectedColor = Color.red;
                btnAddAmmo.GetComponent<Button>().colors = colorsAddA;
            }
            else
            {

                var colorsAddH = btnAddHealth.GetComponent<Button>().colors;
                colorsAddH.normalColor = new Color32(17, 69, 132, 255);
                colorsAddH.highlightedColor = new Color32(11, 47, 91, 255);
                btnAddHealth.GetComponent<Button>().colors = colorsAddH;

                var colorsAddA = btnAddAmmo.GetComponent<Button>().colors;
                colorsAddA.normalColor = new Color32(17, 69, 132, 255);
                colorsAddA.highlightedColor = new Color32(11, 47, 91, 255);
                btnAddAmmo.GetComponent<Button>().colors = colorsAddA;
            }
        }
    }

    public void AddHealth()
    {
        if (PickupItems.coinCounterInt >= 5)
        {
            PickupItems.coinCounterInt -= 5;
            PlayerHealth.currnetHealth += 10;
            healthSlider.value += 10;
            healthSliderWhite.value += 10;
            levelUp.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void RestoreHealth()
    {
        if (PickupItems.coinCounterInt >= 10)
        {
            PickupItems.coinCounterInt -= 10;
            PlayerHealth.currnetHealth = 100;
            healthSlider.value = 100;
            healthSliderWhite.value = 100;
            levelUp.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void AddAmmo()
    {
        if (PickupItems.coinCounterInt >= 5)
        {
            if (pistol.activeSelf)
            {
                PickupItems.coinCounterInt -= 5;
                pistol.GetComponent<PistolShooting>().bulletMaxNumber += 30;
                levelUp.SetActive(false);
                Time.timeScale = 1f;
            }
            if (rifle.activeSelf)
            {
                PickupItems.coinCounterInt -= 5;
                rifle.GetComponent<RifleShooting>().bulletMaxNumber += 30;
                levelUp.SetActive(false);
                Time.timeScale = 1f;
            }
            if (shotgun.activeSelf)
            {
                PickupItems.coinCounterInt -= 5;
                shotgun.GetComponent<ShotgunShooting>().bulletMaxNumber += 30;
                levelUp.SetActive(false);
                Time.timeScale = 1f;
            }
        }
        
    }

    public void AddSpeed()
    {
        if (PickupItems.coinCounterInt >= 10)
        {
            PickupItems.coinCounterInt -= 10;
            playerCircle.GetComponent<PlayerMovement>().speed += 2;
            levelUp.SetActive(false);
            Time.timeScale = 1f;
        }
        
    }

    public void AddDamage()
    {
        if (PickupItems.coinCounterInt >= 10)
        {
            PickupItems.coinCounterInt -= 10;
            bullet.GetComponent<BulletCollision>().bulletDamage += 10;
            levelUp.SetActive(false);
            Time.timeScale = 1f;
        }
        
    }

    public void Exit()
    {
        levelUp.SetActive(false);
        Time.timeScale = 1f;
    }
}
