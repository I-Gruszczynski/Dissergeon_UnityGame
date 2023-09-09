using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    public GameObject hitEffect;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
       if(other.gameObject.tag != "Player" && other.gameObject.tag != "RoomFloor" && other.gameObject.tag != "SpawnPoint" && other.gameObject.tag != "Coin" && other.gameObject.tag != "Ammo" && other.gameObject.tag != "Gun" && other.gameObject.tag != "BulletEnemy" && other.gameObject.tag != "Bullet")
        {
            if (other.gameObject.tag != "Enemy")
            {
                GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.Euler(0, 0, 90) * gameObject.transform.rotation);
                Destroy(effect, 0.5f);
                Destroy(gameObject);
            }
            Destroy(gameObject);
        }

    }

}
