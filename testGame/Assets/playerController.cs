using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{

    public int spd;
    public float accel;
    public float moveSpdX = 0f;
    public float moveSpdY = 0f;

    public float minSpd;
    public float maxSpd;

    public Rigidbody2D rgbody;
    public Animator anim;
    private SpriteRenderer sr;


    private float horizontalMove;
    private float verticalMove;

    //greater than 1 == more friction, less than 1 == less friction
    public float decel;
    
    // Start is called before the first frame update
    void Start()
    {
        accel = 0.8f;
        spd = 10;
        minSpd = -3*spd;
        maxSpd = 3*spd;
        decel = 1.4f;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");
        verticalMove = Input.GetAxisRaw("Vertical");
        // moveSpdX = spd * horizontalMove;
        // moveSpdY = spd * verticalMove;

        // Debug.Log(horizontalMove);

        if(horizontalMove == 0 || Mathf.Sign(horizontalMove) != Mathf.Sign(moveSpdX)){
            moveSpdX = 0;
        }

        if(horizontalMove != 0 && Mathf.Abs(moveSpdX)<spd){
            Debug.Log(horizontalMove);
            moveSpdX += accel * horizontalMove;
        }

        if(verticalMove == 0 || Mathf.Sign(verticalMove) != Mathf.Sign(moveSpdY)){
            moveSpdY = 0;
        }

        if(verticalMove != 0 && Mathf.Abs(moveSpdY)<spd){
            moveSpdY += accel * verticalMove;
        }

        // //horizontal movement 
        // if (horizontalMove == -1 && moveSpdX >= minSpd)
        // {
        //     moveSpdX -= (float)(accel*spd/10);
        //     //   spr.flipX = false;
        //     //   timer = 0;
        // }

        // if (horizontalMove == 1 && moveSpdX <= maxSpd)
        // {
        //     moveSpdX += (float)(accel*spd/10);
        //     //   spr.flipX = true;
        //     //   timer = 0;
        // }

        // if (horizontalMove == 0 && Mathf.Abs(moveSpdX) > 0)
        // {
        //     //   spr.flipX = true;
        //     if (moveSpdX > 0)
        //     {
        //         moveSpdX -= (float)(accel*2*spd/10)*decel;
        //     }
        //     else if (moveSpdX < 0)
        //     {
        //         moveSpdX += (float)(accel*2*spd/10)*decel;
        //     }

        //     if (moveSpdX < .005)
        //     {
        //         moveSpdX = 0.0f;
        //     }
        // }


        // //vertical movement
        // if (verticalMove == -1 && moveSpdY >= minSpd)
        // {
        //     moveSpdY -= (float)(accel*spd/10);
        //     //   spr.flipX = false;
        //     //   timer = 0;
        // }

        // if (verticalMove == 1 && moveSpdY <= maxSpd)
        // {
        //     moveSpdY += (float)(accel*spd/10);
        //     //   spr.flipX = true;
        //     //   timer = 0;
        // }
        
        // if (verticalMove == 0 && Mathf.Abs(moveSpdY) > 0)
        // {
        //     //   spr.flipX = true;
        //     if (moveSpdY > 0)
        //     {
        //         moveSpdY -= (float)(accel*2*spd/10)*decel;
        //     }
        //     else if (moveSpdY < 0)
        //     {
        //         moveSpdY += (float)(accel*2*spd/10)*decel;
        //     }

        //     if (moveSpdY < .005)
        //     {
        //         moveSpdY = 0.0f;
        //     }
        // }


        
    }

    private void FixedUpdate() {
        
        transform.position += new Vector3(moveSpdX * Time.fixedDeltaTime, moveSpdY * Time.fixedDeltaTime, 0);
    }
}
