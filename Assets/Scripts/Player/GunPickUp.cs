using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class GunPickUp : MonoBehaviour
{
    public bool pickUpAllowed;
    public GameObject holder;
    public GameObject objectsContainer;
    public GameObject gunBox;

    public Rigidbody2D rigidbody;
    public Vector2 mousePos;
    public Camera cam;

    public Text gunName;
    public Text gunSpeed;
    public Text gunMaxAmmo;
    public Text gunMagazineAmmo;
    public Text gunReload;

    public Text gunSpeedCurrent;
    public Text gunMaxAmmoCurrent;
    public Text gunMagazineAmmoCurrent;
    public Text gunReloadCurrent;

    public Image gunStatic;

    float gunSpeedCurrentFloat;
    float gunMaxNumberCurrentFloat;
    float bulletMagazineNumberCurrentFloat;
    float reloadTimeCurrentFloat;

    float gunSpeedFloat;
    float gunMaxNumberFloat;
    float bulletMagazineNumberFloat;
    float reloadTimeFloat;

    public GameObject ButtonKey;
    // Start is called before the first frame update
    void Start()
    {
        gunStatic.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {


        if (gameObject.transform.parent.name == "Holder")
            {
                if (gameObject.transform.name == "Shotgun")
                {
                    gunSpeedCurrent.text = gameObject.GetComponent<ShotgunShooting>().bulletSpped.ToString();
                    gunSpeedCurrentFloat = float.Parse(gunSpeedCurrent.text);
                    gunMaxAmmoCurrent.text = gameObject.GetComponent<ShotgunShooting>().bulletMaxNumber.ToString();
                    gunMaxNumberCurrentFloat = gameObject.GetComponent<ShotgunShooting>().bulletMaxNumber;
                    gunMagazineAmmoCurrent.text = gameObject.GetComponent<ShotgunShooting>().bulletMagazineNumber.ToString();
                    bulletMagazineNumberCurrentFloat = gameObject.GetComponent<ShotgunShooting>().bulletMagazineNumber;
                    gunReloadCurrent.text = gameObject.GetComponent<ShotgunShooting>().reloadTime.ToString();
                    reloadTimeCurrentFloat = gameObject.GetComponent<ShotgunShooting>().reloadTime;

                    holder.GetComponentInChildren<GunLayer>().enabled = true;
                    holder.GetComponentInChildren<ShotgunShooting>().enabled = true;
                }
                else if (gameObject.transform.name == "Pistol")
                {
                    gunSpeedCurrent.text = gameObject.GetComponent<PistolShooting>().bulletSpped.ToString();
                    gunSpeedCurrentFloat = float.Parse(gunSpeedCurrent.text);
                    gunMaxAmmoCurrent.text = gameObject.GetComponent<PistolShooting>().bulletMaxNumber.ToString();
                    gunMaxNumberCurrentFloat = gameObject.GetComponent<PistolShooting>().bulletMaxNumber;
                    gunMagazineAmmoCurrent.text = gameObject.GetComponent<PistolShooting>().bulletMagazineNumber.ToString();
                    bulletMagazineNumberCurrentFloat = gameObject.GetComponent<PistolShooting>().bulletMagazineNumber;
                    gunReloadCurrent.text = gameObject.GetComponent<PistolShooting>().reloadTime.ToString();
                    reloadTimeCurrentFloat = gameObject.GetComponent<PistolShooting>().reloadTime;

                    holder.GetComponentInChildren<GunLayer>().enabled = true;
                    holder.GetComponentInChildren<PistolShooting>().enabled = true;
                }
                else if (gameObject.transform.name == "Rifle")
                {
                    gunSpeedCurrent.text = gameObject.GetComponent<RifleShooting>().bulletSpped.ToString();
                    gunSpeedCurrentFloat = float.Parse(gunSpeedCurrent.text);
                    gunMaxAmmoCurrent.text = gameObject.GetComponent<RifleShooting>().bulletMaxNumber.ToString();
                    gunMaxNumberCurrentFloat = gameObject.GetComponent<RifleShooting>().bulletMaxNumber;
                    gunMagazineAmmoCurrent.text = gameObject.GetComponent<RifleShooting>().bulletMagazineNumber.ToString();
                    bulletMagazineNumberCurrentFloat = gameObject.GetComponent<RifleShooting>().bulletMagazineNumber;
                    gunReloadCurrent.text = gameObject.GetComponent<RifleShooting>().reloadTime.ToString();
                    reloadTimeCurrentFloat = gameObject.GetComponent<RifleShooting>().reloadTime;

                    holder.GetComponentInChildren<GunLayer>().enabled = true;
                    holder.GetComponentInChildren<RifleShooting>().enabled = true;
                }
                else
                {
                    return;
                }
            }
            if (pickUpAllowed)
            {
                gunName.text = gameObject.transform.name.ToString();
                if (gameObject.transform.parent.name == "Guns")
                {

                    if (gameObject.transform.name == "Shotgun")
                    {
                        gunSpeed.text = gameObject.GetComponent<ShotgunShooting>().bulletSpped.ToString();
                        gunSpeedFloat = float.Parse(gunSpeed.text);
                        gunMaxAmmo.text = gameObject.GetComponent<ShotgunShooting>().bulletMaxNumber.ToString();
                        gunMaxNumberFloat = gameObject.GetComponent<ShotgunShooting>().bulletMaxNumber;
                        gunMagazineAmmo.text = gameObject.GetComponent<ShotgunShooting>().bulletMagazineNumber.ToString();
                        bulletMagazineNumberFloat = gameObject.GetComponent<ShotgunShooting>().bulletMagazineNumber;
                        gunReload.text = gameObject.GetComponent<ShotgunShooting>().reloadTime.ToString();
                        reloadTimeFloat = gameObject.GetComponent<ShotgunShooting>().reloadTime;
                    }
                    else if (gameObject.transform.name == "Pistol")
                    {
                        gunSpeed.text = gameObject.GetComponent<PistolShooting>().bulletSpped.ToString();
                        gunSpeedFloat = float.Parse(gunSpeed.text);
                        gunMaxAmmo.text = gameObject.GetComponent<PistolShooting>().bulletMaxNumber.ToString();
                        gunMaxNumberFloat = gameObject.GetComponent<PistolShooting>().bulletMaxNumber;
                        gunMagazineAmmo.text = gameObject.GetComponent<PistolShooting>().bulletMagazineNumber.ToString();
                        bulletMagazineNumberFloat = gameObject.GetComponent<PistolShooting>().bulletMagazineNumber;
                        gunReload.text = gameObject.GetComponent<PistolShooting>().reloadTime.ToString();
                        reloadTimeFloat = gameObject.GetComponent<PistolShooting>().reloadTime;
                    }
                    else if (gameObject.transform.name == "Rifle")
                    {
                        gunSpeed.text = gameObject.GetComponent<RifleShooting>().bulletSpped.ToString();
                        gunSpeedFloat = float.Parse(gunSpeed.text);
                        gunMaxAmmo.text = gameObject.GetComponent<RifleShooting>().bulletMaxNumber.ToString();
                        gunMaxNumberFloat = gameObject.GetComponent<RifleShooting>().bulletMaxNumber;
                        gunMagazineAmmo.text = gameObject.GetComponent<RifleShooting>().bulletMagazineNumber.ToString();
                        bulletMagazineNumberFloat = gameObject.GetComponent<RifleShooting>().bulletMagazineNumber;
                        gunReload.text = gameObject.GetComponent<RifleShooting>().reloadTime.ToString();
                        reloadTimeFloat = gameObject.GetComponent<RifleShooting>().reloadTime;
                    }
                    else
                    {
                        return;
                    }
            }
            }
            /*
        if (gunStatic.gameObject.activeSelf)
        {
            //Debug.Log("Szybkość bronni: " + gunSpeedCurrentFloat.ToString() + " i " + gunSpeedFloat.ToString());
            if (gunSpeedCurrentFloat != 0 && gunSpeedFloat != 0)
            {
                if (gunSpeedCurrentFloat < gunSpeedFloat)
                {
                    gunSpeed.color = Color.green;
                }
                else if (gunSpeedCurrentFloat > gunSpeedFloat)
                {
                    gunSpeed.color = Color.red;
                }
                else
                {
                    gunSpeed.color = Color.white;
                }
                Debug.Log("Szybkość bronni: " + gunSpeedCurrentFloat.ToString() + " i " + gunSpeedFloat.ToString());
            }

            if (gunMaxNumberCurrentFloat < gunMaxNumberFloat)
            {
                gunMaxAmmo.color = Color.green;
            }
            else if (gunMaxNumberCurrentFloat > gunMaxNumberFloat)
            {
                gunMaxAmmo.color = Color.red;
            }
            else
            {
                gunMaxAmmo.color = Color.white;
            }


            if (bulletMagazineNumberCurrentFloat < bulletMagazineNumberFloat)
            {
                gunMagazineAmmo.color = Color.green;
            }
            else if (bulletMagazineNumberCurrentFloat > bulletMagazineNumberFloat)
            {
                gunMagazineAmmo.color = Color.red;
            }
            else
            {
                gunMagazineAmmo.color = Color.white;
            }


            if (reloadTimeCurrentFloat < reloadTimeFloat)
            {
                gunReload.color = Color.green;
            }
            else if (reloadTimeCurrentFloat > reloadTimeFloat)
            {
                gunReload.color = Color.red;
            }
            else
            {
                gunReload.color = Color.white;
            }

        }
            */
            //Debug.Log("szybkosc "+ int.Parse(gunSpeedCurrent.ToString()));
        

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (gameObject.transform.parent == holder.transform)
        {
            pickUpAllowed = false;
            gameObject.transform.position = holder.transform.position;
            Vector2 direction = (mousePos - (Vector2)transform.position).normalized;

            // set vector of transform directly
            transform.right = direction;

        }

        if (gameObject.transform.parent == gunBox.transform)
        {
            transform.rotation = Quaternion.Euler(-1.2f, 0.5f, 0);
        }

            if (pickUpAllowed && Input.GetKey(KeyCode.E))
        {
            if (holder.transform.childCount > 0)
            {
                
                holder.transform.GetChild(0).gameObject.transform.SetParent(objectsContainer.transform, true);
                objectsContainer.transform.SetParent(null);

                

                if (objectsContainer.transform.Find("Pistol"))
                {
                    objectsContainer.GetComponentInChildren<GunLayer>().enabled = false;
                    objectsContainer.GetComponentInChildren<PistolShooting>().enabled = false;
                }
                else if (objectsContainer.transform.Find("Rifle"))
                {
                    objectsContainer.GetComponentInChildren<GunLayer>().enabled = false;
                    objectsContainer.GetComponentInChildren<RifleShooting>().enabled = false;
                }
                else if (objectsContainer.transform.Find("Shotgun"))
                {
                    objectsContainer.GetComponentInChildren<GunLayer>().enabled = false;
                    objectsContainer.GetComponentInChildren<ShotgunShooting>().enabled = false;
                }


                //holder.transform.GetChild(0).gameObject.transform.SetParent(gunBox.transform);
            }
            transform.SetParent(holder.transform);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //if (gameObject.transform.parent == objectsContainer.transform || gameObject.transform.parent == gunBox.transform)
            if (gameObject.transform.parent != holder.transform)
            {
                ButtonKey.SetActive(true);
                pickUpAllowed = true;
                gunStatic.gameObject.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
           //if (gameObject.transform.parent == objectsContainer.transform || gameObject.transform.parent == gunBox.transform)
            if (gameObject.transform.parent != holder.transform)
                {
                ButtonKey.SetActive(false);
                pickUpAllowed = false;
                gunStatic.gameObject.SetActive(false);
            }
        }
    }
    
    void FixedUpdate()
    {
        Quaternion savedRotation = gameObject.transform.rotation;
        Vector2 lookDir = mousePos - rigidbody.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rigidbody.rotation = angle;
        gameObject.transform.rotation = savedRotation;

    }
}
