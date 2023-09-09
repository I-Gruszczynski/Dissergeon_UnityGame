using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MousePosition : MonoBehaviour
{
    public Transform childObject;
    public Rigidbody2D rigidbody;
    public Vector2 mousePos;
    public Vector2 move;
    public Camera cam;
    public GameObject gun;
    public int gunOrder;
    public GameObject player;
    public Sprite[] sprites;
    public Animator animatorPlayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        gunOrder = gun.GetComponent<Renderer>().sortingOrder;
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        move = gameObject.GetComponent<PlayerMovement>().move;

       //Debug.Log("Rotacja "+ transform.localRotation.eulerAngles.z);

        if (transform.localRotation.eulerAngles.z > 90 && transform.localRotation.eulerAngles.z < 270)
        {
            
            gunOrder = 4;
        }
        else
        {
           
            gunOrder = 1;
        }
/*
        if (transform.localRotation.eulerAngles.z > 0 && transform.localRotation.eulerAngles.z < 180)
        {

            gun.transform.eulerAngles = new Vector3(0f, 0f, 90f);
            Debug.Log("Gun left "+gun.transform.localRotation.eulerAngles);
        }
        else
        {
            gun.transform.eulerAngles = new Vector3(180f, 0f, 270f);

            Debug.Log("Gun right " + gun.transform.localRotation.eulerAngles);
        }
*/

        //if (transform.localRotation.eulerAngles.z > 30 && transform.localRotation.eulerAngles.z < 60)
        //{
        //Debug.Log("Spite Prawo Ty³");

        if (move.x == 1 && move.y == 1)
                {
                    foreach (var sprite in sprites)
                    {
                        player.GetComponent<SpriteRenderer>().sprite = sprites[7];
                        animatorPlayer.SetBool("PlayerBackRightRun", true);
                        animatorPlayer.SetBool("PlayerRightRun", false);
                        animatorPlayer.SetBool("PlayerFrontRightRun", false);
                        animatorPlayer.SetBool("PlayerFrontRun", false);
                        animatorPlayer.SetBool("PlayerFrontLeftRun", false);
                        animatorPlayer.SetBool("PlayerLeftRun", false);
                        animatorPlayer.SetBool("PlayerBackLeftRun", false);
                        animatorPlayer.SetBool("PlayerBackRun", false);
                animatorPlayer.SetBool("PlayerFrontLeftIdle", false);
                animatorPlayer.SetBool("PlayerLeftIdle", false);
                animatorPlayer.SetBool("PlayerLeftBackIdle", false);
                animatorPlayer.SetBool("PlayerBackIdle", false);
                animatorPlayer.SetBool("PlayerBackRightIdle", false);
                animatorPlayer.SetBool("PlayerRightIdle", false);
                animatorPlayer.SetBool("PlayerFrontRightIdle", false);
                animatorPlayer.SetBool("PlayerFrontIdle", false);

            }
                }
                else if(move.x == 0 && move.y == 0 && transform.localRotation.eulerAngles.z > 30 && transform.localRotation.eulerAngles.z < 60)
                {
                    animatorPlayer.SetBool("PlayerFrontLeftIdle", false);
                    animatorPlayer.SetBool("PlayerLeftIdle", false);
                    animatorPlayer.SetBool("PlayerBackRightIdle", true);
                    animatorPlayer.SetBool("PlayerBackIdle", false);
                    animatorPlayer.SetBool("PlayerBackRightIdle", false);
                    animatorPlayer.SetBool("PlayerRightIdle", false);
                    animatorPlayer.SetBool("PlayerFrontRightIdle", false);
                    animatorPlayer.SetBool("PlayerFrontIdle", false);
                    animatorPlayer.SetBool("PlayerBackRightRun", false);
                }
            
        //}
        //else if (transform.localRotation.eulerAngles.z > 240 && transform.localRotation.eulerAngles.z <= 300)
        //{
            //Debug.Log("Spite Prawo");
        
                if (move.x == 1 && move.y ==0)
                {
                    foreach (var sprite in sprites)
                    {
                        player.GetComponent<SpriteRenderer>().sprite = sprites[3];
                        animatorPlayer.SetBool("PlayerBackLeftRun", false);
                        animatorPlayer.SetBool("PlayerRightRun", true);
                        animatorPlayer.SetBool("PlayerFrontRightRun", false);
                        animatorPlayer.SetBool("PlayerFrontRun", false);
                        animatorPlayer.SetBool("PlayerFrontLeftRun", false);
                        animatorPlayer.SetBool("PlayerLeftRun", false);
                        animatorPlayer.SetBool("PlayerBackRightRun", false);
                        animatorPlayer.SetBool("PlayerBackRun", false);
                animatorPlayer.SetBool("PlayerFrontLeftIdle", false);
                animatorPlayer.SetBool("PlayerLeftIdle", false);
                animatorPlayer.SetBool("PlayerLeftBackIdle", false);
                animatorPlayer.SetBool("PlayerBackIdle", false);
                animatorPlayer.SetBool("PlayerBackRightIdle", false);
                animatorPlayer.SetBool("PlayerRightIdle", false);
                animatorPlayer.SetBool("PlayerFrontRightIdle", false);
                animatorPlayer.SetBool("PlayerFrontIdle", false);
            }
                }
                else if (move.x == 0 && move.y == 0 && transform.localRotation.eulerAngles.z > 240 && transform.localRotation.eulerAngles.z <= 300)
                {
                    animatorPlayer.SetBool("PlayerFrontLeftIdle", false);
                    animatorPlayer.SetBool("PlayerLeftIdle", false);
                    animatorPlayer.SetBool("PlayerLeftBackIdle", false);
                    animatorPlayer.SetBool("PlayerBackIdle", false);
                    animatorPlayer.SetBool("PlayerBackRightIdle", false);
                    animatorPlayer.SetBool("PlayerRightIdle", true);
                    animatorPlayer.SetBool("PlayerFrontRightIdle", false);
                    animatorPlayer.SetBool("PlayerFrontIdle", false);
                    animatorPlayer.SetBool("PlayerRightRun", false);
                }
            
        //}
       //else if (transform.localRotation.eulerAngles.z > 210 && transform.localRotation.eulerAngles.z <= 240)
        //{
            //Debug.Log("Spite Prawo Przód");
            
                if (move.x == 1 && move.y == -1)
                {
                    foreach (var sprite in sprites)
                    {
                        player.GetComponent<SpriteRenderer>().sprite = sprites[5];
                        animatorPlayer.SetBool("PlayerBackLeftRun", false);
                        animatorPlayer.SetBool("PlayerRightRun", false);
                        animatorPlayer.SetBool("PlayerFrontRightRun", true);
                        animatorPlayer.SetBool("PlayerFrontRun", false);
                        animatorPlayer.SetBool("PlayerFrontLeftRun", false);
                        animatorPlayer.SetBool("PlayerLeftRun", false);
                        animatorPlayer.SetBool("PlayerBackRightRun", false);
                        animatorPlayer.SetBool("PlayerBackRun", false);
                animatorPlayer.SetBool("PlayerFrontLeftIdle", false);
                animatorPlayer.SetBool("PlayerLeftIdle", false);
                animatorPlayer.SetBool("PlayerLeftBackIdle", false);
                animatorPlayer.SetBool("PlayerBackIdle", false);
                animatorPlayer.SetBool("PlayerBackRightIdle", false);
                animatorPlayer.SetBool("PlayerRightIdle", false);
                animatorPlayer.SetBool("PlayerFrontRightIdle", false);
                animatorPlayer.SetBool("PlayerFrontIdle", false);
            }
                }
                else if(move.x == 0 && move.y == 0 && transform.localRotation.eulerAngles.z > 210 && transform.localRotation.eulerAngles.z <= 240)
                {
                    animatorPlayer.SetBool("PlayerFrontLeftIdle", false);
                    animatorPlayer.SetBool("PlayerLeftIdle", false);
                    animatorPlayer.SetBool("PlayerLeftBackIdle", false);
                    animatorPlayer.SetBool("PlayerBackIdle", false);
                    animatorPlayer.SetBool("PlayerBackRightIdle", false);
                    animatorPlayer.SetBool("PlayerRightIdle", false);
                    animatorPlayer.SetBool("PlayerFrontRightIdle", true);
                    animatorPlayer.SetBool("PlayerFrontIdle", false);
                    animatorPlayer.SetBool("PlayerFrontRightRun", false);
                }
            
        //}
        //else if (transform.localRotation.eulerAngles.z > 150 && transform.localRotation.eulerAngles.z <= 210)
        //{
            //Debug.Log("Sprite Przód");
            

                if (move.y == -1 && move.x == 0)
                {
                    foreach (var sprite in sprites)
                    {
                        player.GetComponent<SpriteRenderer>().sprite = sprites[0];
                        animatorPlayer.SetBool("PlayerBackLeftRun", false);
                        animatorPlayer.SetBool("PlayerRightRun", false);
                        animatorPlayer.SetBool("PlayerFrontRightRun", false);
                        animatorPlayer.SetBool("PlayerFrontRun", true);
                        animatorPlayer.SetBool("PlayerFrontLeftRun", false);
                        animatorPlayer.SetBool("PlayerLeftRun", false);
                        animatorPlayer.SetBool("PlayerBackRightRun", false);
                        animatorPlayer.SetBool("PlayerBackRun", false);
                animatorPlayer.SetBool("PlayerFrontLeftIdle", false);
                animatorPlayer.SetBool("PlayerLeftIdle", false);
                animatorPlayer.SetBool("PlayerLeftBackIdle", false);
                animatorPlayer.SetBool("PlayerBackIdle", false);
                animatorPlayer.SetBool("PlayerBackRightIdle", false);
                animatorPlayer.SetBool("PlayerRightIdle", false);
                animatorPlayer.SetBool("PlayerFrontRightIdle", false);
                animatorPlayer.SetBool("PlayerFrontIdle", false);
            }
                }
                else if (move.x == 0 && move.y == 0 && transform.localRotation.eulerAngles.z > 150 && transform.localRotation.eulerAngles.z <= 210)
                {
                    animatorPlayer.SetBool("PlayerFrontLeftIdle", false);
                    animatorPlayer.SetBool("PlayerLeftIdle", false);
                    animatorPlayer.SetBool("PlayerLeftBackIdle", false);
                    animatorPlayer.SetBool("PlayerBackIdle", false);
                    animatorPlayer.SetBool("PlayerBackRightIdle", false);
                    animatorPlayer.SetBool("PlayerRightIdle", false);
                    animatorPlayer.SetBool("PlayerFrontRightIdle", false);
                    animatorPlayer.SetBool("PlayerFrontIdle", true);
                    animatorPlayer.SetBool("PlayerFrontRun", false);
                }

        //}
        //else if (transform.localRotation.eulerAngles.z > 120 && transform.localRotation.eulerAngles.z <= 150)
        //{
        //Debug.Log("Sprite Przód Lewo");

        player.GetComponent<SpriteRenderer>().sprite = sprites[4];
                if (move.x == -1 && move.y == -1)
                {
                    foreach (var sprite in sprites)
                    {
                        player.GetComponent<SpriteRenderer>().sprite = sprites[4];
                        animatorPlayer.SetBool("PlayerBackLeftRun", false);
                        animatorPlayer.SetBool("PlayerRightRun", false);
                        animatorPlayer.SetBool("PlayerFrontRightRun", false);
                        animatorPlayer.SetBool("PlayerFrontRun", false);
                        animatorPlayer.SetBool("PlayerFrontLeftRun", true);
                        animatorPlayer.SetBool("PlayerLeftRun", false);
                        animatorPlayer.SetBool("PlayerBackRightRun", false);
                        animatorPlayer.SetBool("PlayerBackRun", false);
                animatorPlayer.SetBool("PlayerFrontLeftIdle", false);
                animatorPlayer.SetBool("PlayerLeftIdle", false);
                animatorPlayer.SetBool("PlayerLeftBackIdle", false);
                animatorPlayer.SetBool("PlayerBackIdle", false);
                animatorPlayer.SetBool("PlayerBackRightIdle", false);
                animatorPlayer.SetBool("PlayerRightIdle", false);
                animatorPlayer.SetBool("PlayerFrontRightIdle", false);
                animatorPlayer.SetBool("PlayerFrontIdle", false);
            }
                }
                else if (move.x == 0 && move.y == 0 && transform.localRotation.eulerAngles.z > 120 && transform.localRotation.eulerAngles.z <= 150)
                {
                    animatorPlayer.SetBool("PlayerFrontLeftIdle", true);
                    animatorPlayer.SetBool("PlayerLeftIdle", false);
                    animatorPlayer.SetBool("PlayerLeftBackIdle", false);
                    animatorPlayer.SetBool("PlayerBackIdle", false);
                    animatorPlayer.SetBool("PlayerBackRightIdle", false);
                    animatorPlayer.SetBool("PlayerRightIdle", false);
                    animatorPlayer.SetBool("PlayerFrontRightIdle", false);
                    animatorPlayer.SetBool("PlayerFrontIdle", false);
                    animatorPlayer.SetBool("PlayerFrontLeftRun", false);
                }
            
        //}
        //else if (transform.localRotation.eulerAngles.z > 60 && transform.localRotation.eulerAngles.z <= 120)
        //{
            //Debug.Log("Spite Lewo");
           
                if (move.x == -1 && move.y == 0)
                {
                    foreach (var sprite in sprites)
                    {
                        player.GetComponent<SpriteRenderer>().sprite = sprites[2];
                        animatorPlayer.SetBool("PlayerBackLeftRun", false);
                        animatorPlayer.SetBool("PlayerRightRun", false);
                        animatorPlayer.SetBool("PlayerFrontRightRun", false);
                        animatorPlayer.SetBool("PlayerFrontRun", false);
                        animatorPlayer.SetBool("PlayerFrontLeftRun", false);
                        animatorPlayer.SetBool("PlayerLeftRun", true);
                        animatorPlayer.SetBool("PlayerBackRightRun", false);
                        animatorPlayer.SetBool("PlayerBackRun", false);
                animatorPlayer.SetBool("PlayerFrontLeftIdle", false);
                animatorPlayer.SetBool("PlayerLeftIdle", false);
                animatorPlayer.SetBool("PlayerLeftBackIdle", false);
                animatorPlayer.SetBool("PlayerBackIdle", false);
                animatorPlayer.SetBool("PlayerBackRightIdle", false);
                animatorPlayer.SetBool("PlayerRightIdle", false);
                animatorPlayer.SetBool("PlayerFrontRightIdle", false);
                animatorPlayer.SetBool("PlayerFrontIdle", false);
            }
                }
                else if(move.x == 0 && move.y == 0 && transform.localRotation.eulerAngles.z > 60 && transform.localRotation.eulerAngles.z <= 120)
                {
                    animatorPlayer.SetBool("PlayerFrontLeftIdle", false);
                    animatorPlayer.SetBool("PlayerLeftIdle", true);
                    animatorPlayer.SetBool("PlayerLeftBackIdle", false);
                    animatorPlayer.SetBool("PlayerBackIdle", false);
                    animatorPlayer.SetBool("PlayerBackRightIdle", false);
                    animatorPlayer.SetBool("PlayerRightIdle", false);
                    animatorPlayer.SetBool("PlayerFrontRightIdle", false);
                    animatorPlayer.SetBool("PlayerFrontIdle", false);
                    animatorPlayer.SetBool("PlayerLeftRun", false);
                }
           
        //}   
        //else if (transform.localRotation.eulerAngles.z > 300 && transform.localRotation.eulerAngles.z <= 330)
        //{
            //Debug.Log("Spite Lewo Ty³");
            
                if (move.x == -1 && move.y == 1)
                {
                    foreach (var sprite in sprites)
                    {
                        player.GetComponent<SpriteRenderer>().sprite = sprites[6];
                        animatorPlayer.SetBool("PlayerBackRightRun", false);
                        animatorPlayer.SetBool("PlayerRightRun", false);
                        animatorPlayer.SetBool("PlayerFrontRightRun", false);
                        animatorPlayer.SetBool("PlayerFrontRun", false);
                        animatorPlayer.SetBool("PlayerFrontLeftRun", false);
                        animatorPlayer.SetBool("PlayerLeftRun", false);
                        animatorPlayer.SetBool("PlayerBackLeftRun", true);
                        animatorPlayer.SetBool("PlayerBackRun", false);
                animatorPlayer.SetBool("PlayerFrontLeftIdle", false);
                animatorPlayer.SetBool("PlayerLeftIdle", false);
                animatorPlayer.SetBool("PlayerLeftBackIdle", false);
                animatorPlayer.SetBool("PlayerBackIdle", false);
                animatorPlayer.SetBool("PlayerBackRightIdle", false);
                animatorPlayer.SetBool("PlayerRightIdle", false);
                animatorPlayer.SetBool("PlayerFrontRightIdle", false);
                animatorPlayer.SetBool("PlayerFrontIdle", false);
            }
                }
                else if (move.x == 0 && move.y == 0 && transform.localRotation.eulerAngles.z > 300 && transform.localRotation.eulerAngles.z <= 330)
                {
                    animatorPlayer.SetBool("PlayerFrontLeftIdle", false);
                    animatorPlayer.SetBool("PlayerLeftIdle", false);
                    animatorPlayer.SetBool("PlayerBackRightIdle", false);
                    animatorPlayer.SetBool("PlayerBackIdle", false);
                    animatorPlayer.SetBool("PlayerLeftBackIdle", true);
                    animatorPlayer.SetBool("PlayerRightIdle", false);
                    animatorPlayer.SetBool("PlayerFrontRightIdle", false);
                    animatorPlayer.SetBool("PlayerFrontIdle", false);
                    animatorPlayer.SetBool("PlayerBackLeftRun", false);
                }
          
        //}  
        //else if ((transform.localRotation.eulerAngles.z > 330 && transform.localRotation.eulerAngles.z <= 360) || (transform.localRotation.eulerAngles.z > 0 && transform.localRotation.eulerAngles.z <= 30))
        //{
            //Debug.Log("Wyj¹tek Plecy");
            
                
                if (move.y == 1 && move.x == 0)
                {
                    foreach (var sprite in sprites)
                    {
                        player.GetComponent<SpriteRenderer>().sprite = sprites[1];
                        animatorPlayer.SetBool("PlayerBackLeftRun", false);
                        animatorPlayer.SetBool("PlayerRightRun", false);
                        animatorPlayer.SetBool("PlayerFrontRightRun", false);
                        animatorPlayer.SetBool("PlayerFrontRun", false);
                        animatorPlayer.SetBool("PlayerFrontLeftRun", false);
                        animatorPlayer.SetBool("PlayerLeftRun", false);
                        animatorPlayer.SetBool("PlayerBackRightRun", false);
                        animatorPlayer.SetBool("PlayerBackRun", true);
                animatorPlayer.SetBool("PlayerFrontLeftIdle", false);
                animatorPlayer.SetBool("PlayerLeftIdle", false);
                animatorPlayer.SetBool("PlayerLeftBackIdle", false);
                animatorPlayer.SetBool("PlayerBackIdle", false);
                animatorPlayer.SetBool("PlayerBackRightIdle", false);
                animatorPlayer.SetBool("PlayerRightIdle", false);
                animatorPlayer.SetBool("PlayerFrontRightIdle", false);
                animatorPlayer.SetBool("PlayerFrontIdle", false);
            }
                }
                else if (move.x == 0 && move.y == 0 && (transform.localRotation.eulerAngles.z > 330 && transform.localRotation.eulerAngles.z <= 360) || (transform.localRotation.eulerAngles.z > 0 && transform.localRotation.eulerAngles.z <= 30))
                {
                    animatorPlayer.SetBool("PlayerFrontLeftIdle", false);
                    animatorPlayer.SetBool("PlayerLeftIdle", false);
                    animatorPlayer.SetBool("PlayerLeftBackIdle", false);
                    animatorPlayer.SetBool("PlayerBackIdle", true);
                    animatorPlayer.SetBool("PlayerBackRightIdle", false);
                    animatorPlayer.SetBool("PlayerRightIdle", false);
                    animatorPlayer.SetBool("PlayerFrontRightIdle", false);
                    animatorPlayer.SetBool("PlayerFrontIdle", false);
                    animatorPlayer.SetBool("PlayerBackRun", false);
                }
            
        //}
    }
    
    void FixedUpdate()
    {
        Quaternion savedRotation = childObject.rotation;
        Vector2 lookDir = mousePos - rigidbody.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rigidbody.rotation = angle;
        childObject.rotation = savedRotation;
        

        
    }
}
