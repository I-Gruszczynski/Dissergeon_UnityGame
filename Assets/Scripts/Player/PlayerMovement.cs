using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    
    public Vector2 move;
    public Vector2 mousePos;
    public Camera cam;

    float x, y;
    public float speed = 8f;

    float activeMoveSpeed;
    public float dashSpeed;

    public float dashLength = 0.5f;
    public float dashCooldown = 1f;

    float dashCounter;
    float dashCoolCounter;

    public ParticleSystem dustEffect;
    // Start is called before the first frame update
    void Start()
    {
        activeMoveSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");

        move = new Vector2(x, y);

        if(move.x != 0 || move.y != 0)
        {
            if (dustEffect.isPlaying == false)
            {
                dustEffect.Play();
                dustEffect.enableEmission = true;
            }
        }

        if (move.x == 0 && move.y == 0)
        {
            if (dustEffect.isStopped == false)
            {
                dustEffect.Stop();
                dustEffect.enableEmission = false;
            }
        }

        //Debug.Log("Wartosci move: " + move);
        //mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (dashCoolCounter <=0 && dashCounter <= 0)
            {
                activeMoveSpeed = dashSpeed;
                dashCounter = dashLength;
            }  
        }

        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;

            if (dashCounter <= 0)
            {
                activeMoveSpeed = speed;
                dashCoolCounter = dashCooldown;
            }
        }

        if (dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;
        }
        
    }
        

    void FixedUpdate()
    {
        rigidbody.MovePosition(rigidbody.position + move * activeMoveSpeed * Time.fixedDeltaTime);

        //Vector2 lookDir = mousePos - rigidbody.position;
        //float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        //rigidbody.rotation = angle;
    }
}
