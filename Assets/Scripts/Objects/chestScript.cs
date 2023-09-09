using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class chestScript : MonoBehaviour
{
    public GameObject[] guns;
    public GameObject gunBox;
    bool canOpen;
    bool isOpen;

    Vector2 startPos;
    Vector2 moveTarget;

    int randMoveX;
    int randMoveY;

    int rand;

    public GameObject ButtonKey;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < guns.Length; i++)
        {
            guns[i].SetActive(false);
        }

        rand = Random.Range(0, guns.Length);

        randMoveX = Random.Range(-2, -4);
        randMoveY = Random.Range(-2, -4);
        //moveTarget = new Vector2(5, 5);
    }

    // Update is called once per frame
    void Update()
    {
        if (canOpen)
        {
            startPos = gunBox.gameObject.transform.position;
            if (Input.GetKeyDown(KeyCode.F))
            {
                isOpen = true;

            }
        }
        if (isOpen)
            {

            moveTarget = new Vector2(gunBox.transform.position.x + randMoveX, gunBox.transform.position.y + randMoveY);
            guns[rand].gameObject.SetActive(true);
            //guns[rand].gameObject.transform.position = gunBox.transform.position;
            //guns[rand].gameObject.transform.position = new Vector2(guns[rand].gameObject.transform.position.x + randMoveX, guns[rand].gameObject.transform.position.y + randMoveY) * Time.deltaTime;
            //guns[rand].gameObject.transform.position = new Vector2(0, 5) * Time.deltaTime;
            //Vector3 targetPosition = new Vector2(gameObject.transform.position.x+5, gameObject.transform.position.y + 5);
                
            guns[rand].transform.position = Vector3.MoveTowards(guns[rand].transform.position, moveTarget, 8 * Time.deltaTime);
            //guns[rand].gameObject.transform.position = Vector2.MoveTowards(startPos, moveTarget, Time.deltaTime * 2);

           
            //guns[rand].gameObject.transform.position += new Vector3(randMoveX, randMoveY, guns[rand].gameObject.transform.position.z) * Time.deltaTime;
            // Debug.Log("Chce pozycje:" + targetPosition);
                canOpen = false;
            }
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Player")
        {
            ButtonKey.SetActive(true);
            canOpen = true;
            Debug.Log("Mo¿na otworzyc skrzynie");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        ButtonKey.SetActive(false);
        canOpen = false;
        Debug.Log("Nie mo¿na otworzyc skrzynii");
    }
}



