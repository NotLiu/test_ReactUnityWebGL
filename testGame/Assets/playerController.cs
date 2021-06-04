using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

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
    public int score;
    
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
    }
    
    [DllImport("__Internal")]
    private static extern void updateScore(int score);

    private void OnCollisionEnter2D(Collision2D other) {
        score += 100;
        
    #if (UNITY_WEBGL == true && UNITY_EDITOR == false)
        updateScore(score);
    #endif  
    }

    private void FixedUpdate() {
        
        transform.position += new Vector3(moveSpdX * Time.fixedDeltaTime, moveSpdY * Time.fixedDeltaTime, 0);
    }
}
