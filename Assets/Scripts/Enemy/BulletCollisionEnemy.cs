using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollisionEnemy : MonoBehaviour
{
    public GameObject hitEffectEnemySlime;
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
       if(other.gameObject.tag != "BulletEnemy" && other.gameObject.tag != "Enemy" && other.gameObject.tag != "RoomFloor" && other.gameObject.tag != "SpawnPoint" && other.gameObject.tag != "Coin" && other.gameObject.tag != "Ammo" && other.gameObject.tag != "Player" && other.gameObject.tag != "Bullet" && other.gameObject.tag != "BrickBorder" && other.gameObject.tag != "Gun")
        {
            if (other.gameObject.tag != "Player")
            {
                GameObject effect = Instantiate(hitEffectEnemySlime, transform.position, Quaternion.Euler(0, 0, 90) * gameObject.transform.rotation);
                Destroy(effect, 0.5f);
                Destroy(gameObject);
            }
            Destroy(gameObject);
        }

    }
}
