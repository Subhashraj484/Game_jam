using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody2D rb;
    BoxCollider2D boxCollider2D;


    [SerializeField] float maxJumpHeight;
    [SerializeField] float maxJumpTime;
    float timetoApex;
    float gravity;
    float initialVelocity;
    float groundedVelocity = -0.5f;
    bool isGrounded;
    float fallGravityMultiplayer = 2;
    float y;
    bool isJumping;


    [SerializeField] float accleration;
    [SerializeField] float deccleration;
    [SerializeField] float maxSpeed;
    [SerializeField] float airSpeed;
    [SerializeField] float maxAirDistance = 4f;

    [SerializeField] LayerMask platformLayer;
    [SerializeField] float boxcastDistance = 1f;
    float x;
    Vector2 targetVelocity;
    Vector2 moveVelocity;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        SetUpJumpProperties();
        InputManager.Instance.OnJump += HandelJump;
    }

    private void HandelJump(object sender, EventArgs e)
    {
         y = initialVelocity;
        isJumping = true;
        Debug.Log("lskdvb");

    }

    // Update is called once per frame
    void Update()
    {
        x = InputManager.Instance.Horizontal;
        float currentSpeed = isGrounded?maxSpeed : airSpeed;
        
        if(Mathf.Abs(x) > 0.1f )
        {
            targetVelocity = new Vector2(x,0)*currentSpeed;
        }
        else
        {
            targetVelocity = Vector2.zero;
        }
        float currentAccleration =  (Mathf.Abs(x) > 0.1f)?accleration : deccleration ;

        moveVelocity = Vector2.Lerp(moveVelocity , targetVelocity ,currentAccleration*Time.deltaTime);


        rb.velocity = new Vector2(moveVelocity.x , y );


        Handelgravity();


    }




    void SetUpJumpProperties()
    {
        timetoApex = maxJumpTime/2;
        initialVelocity = 2*maxJumpHeight / timetoApex;
        gravity = -2*maxJumpHeight / Mathf.Pow(timetoApex , 2);

    }


    void Handelgravity()
    {
        

       
        isGrounded = Physics2D.BoxCast(boxCollider2D.bounds.center , boxCollider2D.bounds.size , 0 , Vector2.down , boxcastDistance , platformLayer);

        if(isGrounded && y <= 0 )
        {
            y = groundedVelocity;
            isJumping = false;
        }
        else
        if(isJumping && y <= 0 )
        {
            float perviousVelocity = y ;
            float newVelcity = perviousVelocity + (gravity*fallGravityMultiplayer);
            float nextvelocity = perviousVelocity + newVelcity * 0.5f * Time.deltaTime;
            y = nextvelocity;

           
        }
        else
        {
            // y += gravity*Time.deltaTime;
            float perviousVelocity = y ;
            float newVelcity = perviousVelocity + gravity;
            float nextvelocity = perviousVelocity + newVelcity * 0.5f * Time.deltaTime;
            y = nextvelocity;

        }

 

        
    }

}
