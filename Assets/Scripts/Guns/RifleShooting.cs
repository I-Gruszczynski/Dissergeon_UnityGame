using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RifleShooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bullet;
    public GameObject player;
    public Animator gunAnimator;

    public float bulletSpped = 25f;
    public int bulletMagazineNumber = 30;
    int bulletMagazineNumberTemp;
    public int bulletMaxNumber = 120;
    public int reloadTime = 2;
    public float cooldown = 1f;
    public float timeStamp = 0f;
    public bool IsAvailable = true;

    public Text AmmoMagazineText;
    public Text MaxAmmoText;
    bool ammoPick;

    float rand1;

    public GameObject holder;
    public GameObject gunBox;
    public GameObject objectContainer;
    bool canShoot;
    // Start is called before the first frame update
    void Start()
    {
        bulletMagazineNumberTemp = bulletMagazineNumber;
    }

    // Update is called once per frame
    void Update()
    {

        if (gameObject.transform.parent == holder.transform)
        {
            canShoot = true;
        }
        if (gameObject.transform.parent == gunBox.transform || gameObject.transform.parent == objectContainer.transform)
        {
            canShoot = false;
        }
        //timeStamp = Time.time + cooldown;
        /*
        if (time >= cooldown)
        {
            time = 0;
        }
        else
        {
            time = +Time.deltaTime;
        }*/

        //Debug.Log("Shoot time: " + timeStamp);
        //Debug.Log("Cooldown: " + cooldown);

        player.transform.rotation = Quaternion.Euler(0, 0, 0);
        //transform.rotation = Quaternion.Euler(0, 0, 0);
        if (canShoot)
        {
            if (Input.GetMouseButton(0) && bulletMagazineNumber > 0)
            {
                if (IsAvailable == false)
                {
                    return;
                }
                else if (IsAvailable == true)
                {
                    gunAnimator.SetBool("RifleRecoil", true);
                    rand1 = UnityEngine.Random.Range(-5f, 5f);
                    Vector3 spread = new Vector3(0, 0, rand1);
                    //Quaternion newRot = Quaternion.Euler(gameObject.transform.localEulerAngles.x, gameObject.transform.localEulerAngles.y, gameObject.transform.localEulerAngles.z + rand1);
                    //Debug.Log(newRot);
                    GameObject bulletVar = Instantiate(bullet, firePoint.position, Quaternion.Euler(firePoint.rotation.eulerAngles + spread));
                    Rigidbody2D rb = bulletVar.GetComponent<Rigidbody2D>();
                    rb.AddForce(bulletVar.transform.up * bulletSpped, ForceMode2D.Impulse);
                    bulletMagazineNumber--;
                    StartCoroutine(StartCooldown());
                }

            }
            else if (Input.GetMouseButton(0) && bulletMagazineNumber <= 0)
            {
                IsAvailable = false;
            }


                if (Input.GetKeyDown(KeyCode.R) || bulletMagazineNumber <= 0)
            {
                if (bulletMagazineNumber != bulletMagazineNumberTemp)
                {
                    StartCoroutine(Reload());
                    bulletMaxNumber = bulletMaxNumber - (bulletMagazineNumberTemp - bulletMagazineNumber);
                    bulletMagazineNumber = bulletMagazineNumberTemp;
                }
            }

            if (Input.GetKeyDown(KeyCode.R) && bulletMaxNumber <= 0)
            {
                IsAvailable = false;
            }


            if (bulletMagazineNumber >=0 && bulletMaxNumber >= 0)
            {
                AmmoMagazineText.text = bulletMagazineNumber.ToString();
                MaxAmmoText.text = bulletMaxNumber.ToString();
            }
            else
            {
                AmmoMagazineText.text = "0";
                MaxAmmoText.text = "0";
                IsAvailable = false;
            }

        }


    }

    IEnumerator Reload()
    {
        IsAvailable = false;
        gunAnimator.SetBool("RifleReload", true);
        yield return new WaitForSeconds(reloadTime);
        gunAnimator.SetBool("RifleReload", false);
        IsAvailable = true;
    }

    public IEnumerator StartCooldown()
    {
        IsAvailable = false;
        yield return new WaitForSeconds(cooldown);
        IsAvailable = true;
    }



}
